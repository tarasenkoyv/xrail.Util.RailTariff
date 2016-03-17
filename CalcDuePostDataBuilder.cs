using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using xrail.Info.Model.Entities;

namespace xrail.Util.RailTariff
{
    public abstract class PostDataBase : IXmlSerializable
    {
        protected PostDataBase()
        {
        }

        #region Private members

        private static readonly XmlWriterSettings XmlWriterSettings = new XmlWriterSettings
        {
            Encoding = Encoding.GetEncoding("UTF-8"),
            OmitXmlDeclaration = false,
            NewLineHandling = NewLineHandling.None
        };
       
        #endregion //Private members

        #region Public methods

        public string GetXml()
        {
            var mXmlQuery = new StringBuilder();

            using (var mWriter = XmlWriter.Create(mXmlQuery, XmlWriterSettings))
            {
                var mSerializer = new XmlSerializer(this.GetType());
                mSerializer.Serialize(mWriter, this);

                mWriter.Flush();
            }

            return mXmlQuery.ToString();
        }

        public static object Deserialize(string pXmlReply, Type pType)
        {
            object mObject;

            using (var mReader = new XmlTextReader(new StringReader(pXmlReply)))
            {
                //Для обработки шестнадцатеричных значений.
                mReader.Normalization = false;
                mReader.WhitespaceHandling = WhitespaceHandling.None;

                var mSerializer = new XmlSerializer(pType);

                mObject = mSerializer.Deserialize(mReader);
            }

            return mObject;
        }

        #endregion //Public methods

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public abstract void WriteXml(XmlWriter writer);

        #endregion //IXmlSerializable
    }

    public class CalcDistancePostDataBuilder
    {
        public int FromStationCode { get; set; }

        public int FromCountryCode { get; set; }

        public int ToStationCode { get; set; }

        public int ToCountryCode { get; set; }

        public string GetPostData()
        {
            var request = new StringBuilder();

            request.Append("argstr=route plType: 1,");
            request.Append(string.Format("countryId:{0},", FromCountryCode));
            request.Append("recipOKPO:,");
            request.Append("recipINN:,");
            request.Append("payerCode:,");
            request.Append(string.Format("{0},", FromStationCode.ToString("00000")));
            request.Append(string.Format("countryId:{0},", ToCountryCode));
            request.Append("recipOKPO:,");
            request.Append("recipINN:,");
            request.Append(string.Format("{0}", ToStationCode.ToString("00000")));

            return request.ToString();
        }
    }

    [XmlRoot("DOCUMENT")]
    public class CalcDueResults : PostDataBase
    {
        #region Properties

        public CalcDueResultsItems Items { get; set; }

        #endregion //Properties

        public override void ReadXml(XmlReader reader)
        {
            var xmlRoot = (XmlRootAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(XmlRootAttribute));

            while (reader.Read() && (reader.IsStartElement() || xmlRoot.ElementName != reader.Name))
            {
                switch (reader.Name)
                {
                    case "SUBDOCUMENT":
                        Items = new CalcDueResultsItems();
                        Items.ReadXml(reader);
                        break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    [XmlRoot("SUBDOCUMENT")]
    public class CalcDueResultsItems : PostDataBase
    {
        public CalcDueResultsItems()
        {
        }

        #region Properties

        public CalcDueResultsItem Items { get; set;}

        #endregion //Properties

        public override void ReadXml(XmlReader reader)
        {
            var xmlRoot = (XmlRootAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(XmlRootAttribute));

            while (reader.Read() && (reader.IsStartElement() || xmlRoot.ElementName != reader.Name))
            {
                switch (reader.Name)
                {
                    case "DWROW":
                        var order = int.Parse(reader.GetAttribute("SelfID"));
                        Items = new CalcDueResultsItem(order);
                        Items.ReadXml(reader);
                        break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    [XmlRoot("DWROW")]
    public class CalcDueResultsItem : PostDataBase
    {
        public CalcDueResultsItem(int order)
        {
        }

        #region Properties
        
        public CalcDueResultsItemDues Dues { get; set;}

        #endregion //Properties

        public override void ReadXml(XmlReader reader)
        {
            var xmlRoot = (XmlRootAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(XmlRootAttribute));

            while (reader.Read() && (reader.IsStartElement() || xmlRoot.ElementName != reader.Name))
            {
                var name = reader.GetAttribute("Name");
                switch (name)
                {
                    case "СБОРЫ":
                        Dues = new CalcDueResultsItemDues();
                        Dues.ReadXml(reader);
                        break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// СБОРЫ.
    /// </summary>
    [XmlRoot("SUBDOCUMENT")]
    public class CalcDueResultsItemDues : PostDataBase
    {
        public CalcDueResultsItemDues()
        {
            this.Items = new List<CalcDueResultsItemDue>();
        }

        #region Properties

        public List<CalcDueResultsItemDue> Items { get; set; }

        #endregion //Properties

        public override void ReadXml(XmlReader reader)
        {
            var xmlRoot = (XmlRootAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(XmlRootAttribute));

            while (reader.Read() && (reader.IsStartElement() || xmlRoot.ElementName != reader.Name))
            {
                switch (reader.Name)
                {
                    case "DWROW":
                        var order = int.Parse(reader.GetAttribute("SelfID"));
                        var item = new CalcDueResultsItemDue(order);
                        item.ReadXml(reader);
                        this.Items.Add(item);
                        break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    [XmlRoot("DWROW")]
    public class CalcDueResultsItemDue : PostDataBase
    {
        public CalcDueResultsItemDue(int order)
        {
            Order = order;
        }

        #region Properties

        /// <summary>
        /// Attribute [SelfID] of <DWROW>.
        /// </summary>
        public int Order { get; set; }

        public int Amount { get; set; }

        public string DueType { get; set; }

        public int CarNumber { get; set; }

        #endregion //Properties

        public override void ReadXml(XmlReader reader)
        {
            var xmlRoot = (XmlRootAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(XmlRootAttribute));

            this.Order = int.Parse(reader.GetAttribute("SelfID"));

            while (reader.Read() && (reader.IsStartElement() || xmlRoot.ElementName != reader.Name))
            {
                var name = reader.GetAttribute("Name");
                switch (name)
                {
                    case "ТИП СБОРА":
                        this.DueType = reader.GetAttribute("Value");
                        break;
                    case "СУММА РУБ":
                        this.Amount = int.Parse(reader.GetAttribute("Value"));
                        break;
                    case "НОМЕР ВАГОНА":
                        this.CarNumber = int.Parse(reader.GetAttribute("Value"));
                        break;
                }
            }
        }
        
        public override void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    [XmlRoot("DOCUMENT")]
    public class CalcDuePostDataBuilder : PostDataBase
    {
        public CalcDuePostDataBuilder()
        {
            DateReady = DateTime.Now;
        }

        private static readonly XmlWriterSettings XmlWriterSettings = new XmlWriterSettings
        {
            Encoding = Encoding.GetEncoding("UTF-8"),
            OmitXmlDeclaration = false,
            NewLineHandling = NewLineHandling.None
        };

        public CalcDuePostDataBuilder(DateTime dateReady, long dispKindID, long sendKindID, long speedID, List<Wag> cars, Freight freight, List<Distance> distances)
        {
            Freight = freight;
            Cars = cars;

            this.Distances = distances;

            this.DispKindID = dispKindID;
            this.SendKindID = sendKindID;
            this.SpeedID = speedID;
            this.DateReady = dateReady;
        }

        #region Properties

        List<Wag> Cars { get; set; }

        public Freight Freight { get; set; }

        public long DispKindID { get; set; }

        public long SendKindID { get; set; }

        public long SpeedID { get; set; }

        public long WagTypeID { get; set; }

        public DateTime DateReady { get; set; }

        public List<Distance> Distances { get; set; }

        #endregion //Properties
        
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", "dwInvoice");

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pINV_DispKind_ID");
            writer.WriteAttributeString("Value", DispKindID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pINV_SendKind_ID");
            writer.WriteAttributeString("Value", SendKindID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pINV_Speed_ID");
            writer.WriteAttributeString("Value", SpeedID.ToString());
            writer.WriteEndElement();
            
            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pINV_Date_Load");
            writer.WriteAttributeString("Value", this.DateReady.ToString("dd.MM.yyyy"));
            writer.WriteEndElement();

            #region Cars

            writer.WriteStartElement("SUBDOCUMENT");
            writer.WriteAttributeString("Name", "Wag");

            foreach (var car in Cars)
            {
                writer.WriteStartElement("DWROW");
                car.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            #endregion //Cars

            #region Distances

            writer.WriteStartElement("SUBDOCUMENT");
            writer.WriteAttributeString("Name", "Distances");

            foreach (var dist in Distances)
            {
                writer.WriteStartElement("DWROW");
                dist.WriteXml(writer);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            #endregion //Distances

            #region Freight

            writer.WriteStartElement("SUBDOCUMENT");
            Freight.WriteXml(writer);
            writer.WriteEndElement();
            
            #endregion //Freight
        }
        
        public string GetPostData()
        {
            var request = new StringBuilder();

            var xml = this.GetXml();
            request.Append(String.Format("argstr=price-longxml {0}", xml));

            return request.ToString();
        }
    }

    [XmlRoot("DWROW")]
    public class Wag : IXmlSerializable
    {
        public Wag(int order)
        {
            Number = 11111110;
            Order = order;
        }

        #region Properties

        /// <summary>
        /// Attribute [SelfID] of <DWROW>.
        /// </summary>
        public int Order { get; set; }

        public byte OwnerTypeID { get; set; }

        public byte Axles { get; set; }

        public int Number { get; set; }

        public long WagTypeID { get; set; }

        public int WagTypeCode { get; set; }

        public double Tonnage { get; set; }

        public int WeightNet { get; set; }

        #endregion //Properties

        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader pReader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            var numberFormat = CultureInfo.CreateSpecificCulture("en-US").NumberFormat;
            
            writer.WriteAttributeString("SelfID", Order.ToString());

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pWAG_OWNERTYPE_ID");
            writer.WriteAttributeString("Value", OwnerTypeID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pWAG_Axles");
            writer.WriteAttributeString("Value", Axles.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pWAG_WagNum");
            writer.WriteAttributeString("Value", Number.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pWAG_Tonnage");
            writer.WriteAttributeString("Value", Tonnage.ToString("0.0", numberFormat));
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pWAG_WEIGHTNET");
            writer.WriteAttributeString("Value", WeightNet.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pWAG_WagType_Id");
            writer.WriteAttributeString("Value", WagTypeID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pWAG_WagType_Code");
            writer.WriteAttributeString("Value", WagTypeCode.ToString());
            writer.WriteEndElement();
        }
    }

    [XmlRoot("SUBDOCUMENT")]
    public class Freight : IXmlSerializable
    {
        public Freight(InfoFreight freight, int weightReal)
        {
            Code = freight.CodeETSNG;
            Class = freight.Class;
            
            WeightReal = weightReal;
        }

        #region Properties

        public int Code { get; set; }
        public byte Class { get; set; }

        public int WeightReal { get; set; }



        #endregion //Properties

        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader pReader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", "Goods");

            writer.WriteStartElement("DWROW");
            writer.WriteAttributeString("SelfID", "0");

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pGDS_FREIGHTCODE");
            writer.WriteAttributeString("Value", Code.ToString("00000"));
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pGDS_ClassCode");
            writer.WriteAttributeString("Value", Class.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pGDS_WeightReal");
            writer.WriteAttributeString("Value", WeightReal.ToString());
            writer.WriteEndElement();
            
            writer.WriteEndElement();
        }
    }

    [XmlRoot("DWROW")]
    public class Distance : PostDataBase
    {
        public Distance(int order)
        {
            Order = order;
        }

        #region Properties

        /// <summary>
        /// Attribute [SelfID] of <DWROW>.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// pDST_COUNTRY_ID.
        /// </summary>
        public int CountryID { get; set; }

        /// <summary>
        /// pDST_TRACKTYPE_ID.
        /// </summary>
        public byte TrackTypeID { get; set; }

        /// <summary>
        /// pDST_TRANSPTYPE_ID.
        /// </summary>
        public byte TransTypeID { get; set; }

        /// <summary>
        /// pDST_CN_SIGN.
        /// </summary>
        public int CnSign { get; set; }

        /// <summary>
        /// pDST_ST_CN_ID.
        /// </summary>
        public int StCnID { get; set; }

        /// <summary>
        /// pDST_ST_CN_ID_Real.
        /// </summary>
        public int StCnIDReal { get; set; }

        /// <summary>
        /// pDST_ST_CN_SIGN.
        /// </summary>
        public int StCnSign { get; set; }

        /// <summary>
        /// pDST_ST_CN_Real_SIGN.
        /// </summary>
        public int StCnRealSign { get; set; }

        /// <summary>
        /// pDST_ST_PROMIVKA_SIGN.
        /// </summary>
        public byte StPromivkaSign { get; set; }

        /// <summary>
        /// pDST_ST_BORDER_SIGN.
        /// </summary>
        public byte StBorderSign { get; set; }

        /// <summary>
        /// pDST_ST_SEA_IM_EX.
        /// </summary>
        public byte StSeaImEx { get; set; }

        /// <summary>
        /// pDST_ST_RIVER_IM_EX.
        /// </summary>
        public byte StRiverImEx { get; set; }

        /// <summary>
        /// pDST_ST_FERRY_IM_EX.
        /// </summary>
        public byte StFerryImEx { get; set; }

        /// <summary>
        /// pDST_STATION_ID.
        /// </summary>
        public long StationID { get; set; }

        /// <summary>
        /// pDST_stationCode.
        /// </summary>
        public int StationCode { get; set; }

        /// <summary>
        /// pDST_rw_id.
        /// </summary>
        public int RwID { get; set; }

        /// <summary>
        /// pDST_minway.
        /// </summary>
        public int MinWay { get; set; }

        /// <summary>
        /// pDst_Port_ID.
        /// </summary>
        public string PortID { get; set; }

        /// <summary>
        /// pDst_ST_RG_ID.
        /// </summary>
        public int StRgID { get; set; }

        /// <summary>
        /// pDST_ST_UZEL
        /// </summary>
        public string StUzel { get; set; }

        /// <summary>
        /// pDST_RecipOKPO
        /// </summary>
        public string RecipOKPO { get; set; }

        /// <summary>
        /// pDST_RecipINN
        /// </summary>
        public string RecipINN { get; set; }

        /// <summary>
        /// pDST_PayerCode
        /// </summary>
        public string PayerCode { get; set; }

        /// <summary>
        /// pDst_SIGN.
        /// </summary>
        public string Sign { get; set; }

        #endregion //Properties

        public override void ReadXml(XmlReader reader)
        {
            var xmlRoot = (XmlRootAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(XmlRootAttribute));

            this.Order = int.Parse(reader.GetAttribute("SelfID"));

            while (reader.Read() && (reader.IsStartElement() || xmlRoot.ElementName != reader.Name))
            {
                var name = reader.GetAttribute("NAME");
                switch (name)
                {
                    case "pDST_COUNTRY_ID":
                        this.CountryID = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_TRACKTYPE_ID":
                        this.TrackTypeID = byte.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_TRANSPTYPE_ID":
                        this.TransTypeID = byte.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_CN_SIGN":
                        this.CnSign = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_CN_ID":
                        this.StCnID = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_CN_ID_Real":
                        this.StCnRealSign = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_CN_SIGN":
                        this.StCnSign = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_CN_Real_SIGN":
                        this.StCnRealSign = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_PROMIVKA_SIGN":
                        this.StPromivkaSign = byte.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_BORDER_SIGN":
                        this.StBorderSign = byte.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_SEA_IM_EX":
                        this.StSeaImEx = byte.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_RIVER_IM_EX":
                        this.StRiverImEx = byte.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_ST_FERRY_IM_EX":
                        this.StFerryImEx = byte.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_STATION_ID":
                        this.StationID = long.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_stationCode":
                        this.StationCode = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_rw_id":
                        this.RwID = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDST_minway":
                        this.MinWay = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDst_Port_ID":
                        this.PortID = reader.GetAttribute("VALUE");
                        break;
                    case "pDST_ST_UZEL":
                        this.StUzel = reader.GetAttribute("VALUE");
                        break;
                    case "pDST_RecipOKPO":
                        this.RecipOKPO = reader.GetAttribute("VALUE");
                        break;
                    case "pDST_RecipINN":
                        this.RecipINN = reader.GetAttribute("VALUE");
                        break;
                    case "pDST_PayerCode":
                        this.PayerCode = reader.GetAttribute("VALUE");
                        break;
                    case "pDst_ST_RG_ID":
                        this.StRgID = int.Parse(reader.GetAttribute("VALUE"));
                        break;
                    case "pDst_SIGN":
                        this.Sign = reader.GetAttribute("VALUE");
                        break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("SelfID", Order.ToString());

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_COUNTRY_ID");
            writer.WriteAttributeString("Value", CountryID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_TRACKTYPE_ID");
            writer.WriteAttributeString("Value", TrackTypeID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_TRANSPTYPE_ID");
            writer.WriteAttributeString("Value", TransTypeID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_CN_SIGN");
            writer.WriteAttributeString("Value", StCnSign.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_CN_ID");
            writer.WriteAttributeString("Value", StCnID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_CN_ID_Real");
            writer.WriteAttributeString("Value", StCnIDReal.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_CN_SIGN");
            writer.WriteAttributeString("Value", StCnSign.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_CN_Real_SIGN");
            writer.WriteAttributeString("Value", StCnRealSign.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_PROMIVKA_SIGN");
            writer.WriteAttributeString("Value", StPromivkaSign.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_BORDER_SIGN");
            writer.WriteAttributeString("Value", StBorderSign.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_SEA_IM_EX");
            writer.WriteAttributeString("Value", StSeaImEx.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_RIVER_IM_EX");
            writer.WriteAttributeString("Value", StRiverImEx.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_FERRY_IM_EX");
            writer.WriteAttributeString("Value", StFerryImEx.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_STATION_ID");
            writer.WriteAttributeString("Value", StationID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_stationCode");
            writer.WriteAttributeString("Value", StationCode.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_rw_id");
            writer.WriteAttributeString("Value", RwID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_minway");
            writer.WriteAttributeString("Value", MinWay.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDst_Port_ID");
            writer.WriteAttributeString("Value", PortID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_ST_UZEL");
            writer.WriteAttributeString("Value", StUzel);
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_RecipOKPO");
            writer.WriteAttributeString("Value", RecipOKPO);
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_RecipINN");
            writer.WriteAttributeString("Value", RecipINN);
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDST_PayerCode");
            writer.WriteAttributeString("Value", PayerCode);
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDst_ST_RG_ID");
            writer.WriteAttributeString("Value", StRgID.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("FIELD");
            writer.WriteAttributeString("Name", "pDst_SIGN");
            writer.WriteAttributeString("Value", Sign.ToString());
            writer.WriteEndElement();
        }
    }

    [XmlRoot("SUBDOCUMENT")]
    public class Distances : PostDataBase
    {
        public Distances()
        {
            List = new List<Distance>();
        }

        public List<Distance> List { get; set; }

        public override void ReadXml(XmlReader reader)
        {
            var xmlRoot = (XmlRootAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(XmlRootAttribute));

            while (reader.Read() && (reader.IsStartElement() || xmlRoot.ElementName != reader.Name))
            {
                switch (reader.Name)
                {
                    case "DWROW":
                        var order = int.Parse(reader.GetAttribute("SelfID"));
                        var dist = new Distance(order);
                        dist.ReadXml(reader);
                        this.List.Add(dist);
                        break;
                }
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", "Distances");

            foreach (var dist in List)
            {
                writer.WriteStartElement("DWROW");
                dist.WriteXml(writer);
                writer.WriteEndElement();
            }
            
        }

    }
}
