using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrail.Util.RailTariff
{
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/ResultSchema.xsd")]
    [System.Xml.Serialization.XmlRootAttribute("ResultTable", Namespace = "http://tempuri.org/ResultSchema.xsd", IsNullable = false)]
    public partial class Result
    {

        private Request request;

        private ResultKIT[] specialTariff;

        private ResultParameter[] parameter;

        private string errorMessage;

        /// <remarks/>
        public Request Request
        {
            get
            {
                return this.request;
            }
            set
            {
                this.request = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("KIT", IsNullable = false)]
        public ResultKIT[] SpecialTariff
        {
            get
            {
                return this.specialTariff;
            }
            set
            {
                this.specialTariff = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Parameter")]
        public ResultParameter[] Parameter
        {
            get
            {
                return this.parameter;
            }
            set
            {
                this.parameter = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                this.errorMessage = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/PostSchema.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/PostSchema.xsd", IsNullable = false)]
    public partial class Request
    {

        private RequestSend send;

        private RequestFreight freight;

        private RequestMxFreight[] mXFreight;

        private RequestSupport support;

        private RequestSetTax[] setTax;

        private RequestFilteredRefBook filteredRefBook;

        private RequestSpecialTariff specialTariff;

        private RequestKIT[] kIT;

        private RequestRur2Usd rur2Usd;

        private RequestSetLandCurrency setLandCurrency;

        private RequestSetCommonCurrency setCommonCurrency;

        private RequestOnDate onDate;

        private RequestFromStation fromStation;

        private RequestToStation toStation;

        private RequestSetReadressingStation setReadressingStation;

        private RequestSetDispStation setDispStation;

        private RequestSetWashingStation setWashingStation;

        private RequestSetUncouplingStation setUncouplingStation;

        private RequestSetRepairStation setRepairStation;

        private RequestSetRate[] setRate;

        private RequestLoadRateFromSite loadRateFromSite;

        private RequestThruRoutes[] thruRoutes;

        private RequestWagon wagon;

        private RequestEmptyWagon emptyWagon;

        private RequestRefWagon refWagon;

        private RequestContainer container;

        private RequestContainerTransport containerTransport;

        private RequestContainerTransportKRK containerTransportKRK;

        /// <remarks/>
        public RequestSend Send
        {
            get
            {
                return this.send;
            }
            set
            {
                this.send = value;
            }
        }

        /// <remarks/>
        public RequestFreight Freight
        {
            get
            {
                return this.freight;
            }
            set
            {
                this.freight = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("mxFreight", IsNullable = false)]
        public RequestMxFreight[] MXFreight
        {
            get
            {
                return this.mXFreight;
            }
            set
            {
                this.mXFreight = value;
            }
        }

        /// <remarks/>
        public RequestSupport Support
        {
            get
            {
                return this.support;
            }
            set
            {
                this.support = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SetTax")]
        public RequestSetTax[] SetTax
        {
            get
            {
                return this.setTax;
            }
            set
            {
                this.setTax = value;
            }
        }

        /// <remarks/>
        public RequestFilteredRefBook FilteredRefBook
        {
            get
            {
                return this.filteredRefBook;
            }
            set
            {
                this.filteredRefBook = value;
            }
        }

        /// <remarks/>
        public RequestSpecialTariff SpecialTariff
        {
            get
            {
                return this.specialTariff;
            }
            set
            {
                this.specialTariff = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KIT")]
        public RequestKIT[] KIT
        {
            get
            {
                return this.kIT;
            }
            set
            {
                this.kIT = value;
            }
        }

        /// <remarks/>
        public RequestRur2Usd Rur2Usd
        {
            get
            {
                return this.rur2Usd;
            }
            set
            {
                this.rur2Usd = value;
            }
        }

        /// <remarks/>
        public RequestSetLandCurrency SetLandCurrency
        {
            get
            {
                return this.setLandCurrency;
            }
            set
            {
                this.setLandCurrency = value;
            }
        }

        /// <remarks/>
        public RequestSetCommonCurrency SetCommonCurrency
        {
            get
            {
                return this.setCommonCurrency;
            }
            set
            {
                this.setCommonCurrency = value;
            }
        }

        /// <remarks/>
        public RequestOnDate OnDate
        {
            get
            {
                return this.onDate;
            }
            set
            {
                this.onDate = value;
            }
        }

        /// <remarks/>
        public RequestFromStation FromStation
        {
            get
            {
                return this.fromStation;
            }
            set
            {
                this.fromStation = value;
            }
        }

        /// <remarks/>
        public RequestToStation ToStation
        {
            get
            {
                return this.toStation;
            }
            set
            {
                this.toStation = value;
            }
        }

        /// <remarks/>
        public RequestSetReadressingStation SetReadressingStation
        {
            get
            {
                return this.setReadressingStation;
            }
            set
            {
                this.setReadressingStation = value;
            }
        }

        /// <remarks/>
        public RequestSetDispStation SetDispStation
        {
            get
            {
                return this.setDispStation;
            }
            set
            {
                this.setDispStation = value;
            }
        }

        /// <remarks/>
        public RequestSetWashingStation SetWashingStation
        {
            get
            {
                return this.setWashingStation;
            }
            set
            {
                this.setWashingStation = value;
            }
        }

        /// <remarks/>
        public RequestSetUncouplingStation SetUncouplingStation
        {
            get
            {
                return this.setUncouplingStation;
            }
            set
            {
                this.setUncouplingStation = value;
            }
        }

        /// <remarks/>
        public RequestSetRepairStation SetRepairStation
        {
            get
            {
                return this.setRepairStation;
            }
            set
            {
                this.setRepairStation = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SetRate")]
        public RequestSetRate[] SetRate
        {
            get
            {
                return this.setRate;
            }
            set
            {
                this.setRate = value;
            }
        }

        /// <remarks/>
        public RequestLoadRateFromSite LoadRateFromSite
        {
            get
            {
                return this.loadRateFromSite;
            }
            set
            {
                this.loadRateFromSite = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ThruRoutes")]
        public RequestThruRoutes[] ThruRoutes
        {
            get
            {
                return this.thruRoutes;
            }
            set
            {
                this.thruRoutes = value;
            }
        }

        /// <remarks/>
        public RequestWagon Wagon
        {
            get
            {
                return this.wagon;
            }
            set
            {
                this.wagon = value;
            }
        }

        /// <remarks/>
        public RequestEmptyWagon EmptyWagon
        {
            get
            {
                return this.emptyWagon;
            }
            set
            {
                this.emptyWagon = value;
            }
        }

        /// <remarks/>
        public RequestRefWagon RefWagon
        {
            get
            {
                return this.refWagon;
            }
            set
            {
                this.refWagon = value;
            }
        }

        /// <remarks/>
        public RequestContainer Container
        {
            get
            {
                return this.container;
            }
            set
            {
                this.container = value;
            }
        }

        /// <remarks/>
        public RequestContainerTransport ContainerTransport
        {
            get
            {
                return this.containerTransport;
            }
            set
            {
                this.containerTransport = value;
            }
        }

        /// <remarks/>
        public RequestContainerTransportKRK ContainerTransportKRK
        {
            get
            {
                return this.containerTransportKRK;
            }
            set
            {
                this.containerTransportKRK = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSend
    {

        private int sendCat;

        private bool sendCatSpecified;

        private int sendId;

        private bool sendIdSpecified;

        private int exitRoute;

        private bool exitRouteSpecified;

        private int speed;

        private bool speedSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SendCat
        {
            get
            {
                return this.sendCat;
            }
            set
            {
                this.sendCat = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SendCatSpecified
        {
            get
            {
                return this.sendCatSpecified;
            }
            set
            {
                this.sendCatSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SendId
        {
            get
            {
                return this.sendId;
            }
            set
            {
                this.sendId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SendIdSpecified
        {
            get
            {
                return this.sendIdSpecified;
            }
            set
            {
                this.sendIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ExitRoute
        {
            get
            {
                return this.exitRoute;
            }
            set
            {
                this.exitRoute = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExitRouteSpecified
        {
            get
            {
                return this.exitRouteSpecified;
            }
            set
            {
                this.exitRouteSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SpeedSpecified
        {
            get
            {
                return this.speedSpecified;
            }
            set
            {
                this.speedSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestFreight
    {

        private string eTSNG;

        private string gNG;

        private string gNG2004;

        private string gNG2007;

        private double weight;

        private bool weightSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ETSNG
        {
            get
            {
                return this.eTSNG;
            }
            set
            {
                this.eTSNG = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GNG
        {
            get
            {
                return this.gNG;
            }
            set
            {
                this.gNG = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GNG2004
        {
            get
            {
                return this.gNG2004;
            }
            set
            {
                this.gNG2004 = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GNG2007
        {
            get
            {
                return this.gNG2007;
            }
            set
            {
                this.gNG2007 = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WeightSpecified
        {
            get
            {
                return this.weightSpecified;
            }
            set
            {
                this.weightSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreight
    {

        private RequestMxFreightFreight freight;

        private RequestMxFreightFreightEx freightEx;

        private RequestMxFreightOversize oversize;

        private RequestMxFreightDanger danger;

        private RequestMxFreightDangerPid dangerPid;

        private RequestMxFreightPerishable perishable;

        private RequestMxFreightSetDefaultParams setDefaultParams;

        /// <remarks/>
        public RequestMxFreightFreight Freight
        {
            get
            {
                return this.freight;
            }
            set
            {
                this.freight = value;
            }
        }

        /// <remarks/>
        public RequestMxFreightFreightEx FreightEx
        {
            get
            {
                return this.freightEx;
            }
            set
            {
                this.freightEx = value;
            }
        }

        /// <remarks/>
        public RequestMxFreightOversize Oversize
        {
            get
            {
                return this.oversize;
            }
            set
            {
                this.oversize = value;
            }
        }

        /// <remarks/>
        public RequestMxFreightDanger Danger
        {
            get
            {
                return this.danger;
            }
            set
            {
                this.danger = value;
            }
        }

        /// <remarks/>
        public RequestMxFreightDangerPid DangerPid
        {
            get
            {
                return this.dangerPid;
            }
            set
            {
                this.dangerPid = value;
            }
        }

        /// <remarks/>
        public RequestMxFreightPerishable Perishable
        {
            get
            {
                return this.perishable;
            }
            set
            {
                this.perishable = value;
            }
        }

        /// <remarks/>
        public RequestMxFreightSetDefaultParams SetDefaultParams
        {
            get
            {
                return this.setDefaultParams;
            }
            set
            {
                this.setDefaultParams = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreightFreight
    {

        private int codeType;

        private bool codeTypeSpecified;

        private string freightCode;

        private double weight;

        private bool weightSpecified;

        private int isGuard;

        private bool isGuardSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CodeType
        {
            get
            {
                return this.codeType;
            }
            set
            {
                this.codeType = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CodeTypeSpecified
        {
            get
            {
                return this.codeTypeSpecified;
            }
            set
            {
                this.codeTypeSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FreightCode
        {
            get
            {
                return this.freightCode;
            }
            set
            {
                this.freightCode = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WeightSpecified
        {
            get
            {
                return this.weightSpecified;
            }
            set
            {
                this.weightSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IsGuard
        {
            get
            {
                return this.isGuard;
            }
            set
            {
                this.isGuard = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsGuardSpecified
        {
            get
            {
                return this.isGuardSpecified;
            }
            set
            {
                this.isGuardSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreightFreightEx
    {

        private string eTSNG;

        private string gNG;

        private double weight;

        private bool weightSpecified;

        private int isGuard;

        private bool isGuardSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ETSNG
        {
            get
            {
                return this.eTSNG;
            }
            set
            {
                this.eTSNG = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GNG
        {
            get
            {
                return this.gNG;
            }
            set
            {
                this.gNG = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WeightSpecified
        {
            get
            {
                return this.weightSpecified;
            }
            set
            {
                this.weightSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IsGuard
        {
            get
            {
                return this.isGuard;
            }
            set
            {
                this.isGuard = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsGuardSpecified
        {
            get
            {
                return this.isGuardSpecified;
            }
            set
            {
                this.isGuardSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreightOversize
    {

        private short item;

        private bool itemSpecified;

        private string oversizeIndex;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ItemSpecified
        {
            get
            {
                return this.itemSpecified;
            }
            set
            {
                this.itemSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OversizeIndex
        {
            get
            {
                return this.oversizeIndex;
            }
            set
            {
                this.oversizeIndex = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreightDanger
    {

        private short item;

        private bool itemSpecified;

        private bool enable;

        private bool enableSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ItemSpecified
        {
            get
            {
                return this.itemSpecified;
            }
            set
            {
                this.itemSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Enable
        {
            get
            {
                return this.enable;
            }
            set
            {
                this.enable = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnableSpecified
        {
            get
            {
                return this.enableSpecified;
            }
            set
            {
                this.enableSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreightDangerPid
    {

        private short item;

        private bool itemSpecified;

        private int dangPid;

        private bool dangPidSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ItemSpecified
        {
            get
            {
                return this.itemSpecified;
            }
            set
            {
                this.itemSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int DangPid
        {
            get
            {
                return this.dangPid;
            }
            set
            {
                this.dangPid = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DangPidSpecified
        {
            get
            {
                return this.dangPidSpecified;
            }
            set
            {
                this.dangPidSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreightPerishable
    {

        private short item;

        private bool itemSpecified;

        private bool enable;

        private bool enableSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ItemSpecified
        {
            get
            {
                return this.itemSpecified;
            }
            set
            {
                this.itemSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Enable
        {
            get
            {
                return this.enable;
            }
            set
            {
                this.enable = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnableSpecified
        {
            get
            {
                return this.enableSpecified;
            }
            set
            {
                this.enableSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestMxFreightSetDefaultParams
    {

        private short item;

        private bool itemSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ItemSpecified
        {
            get
            {
                return this.itemSpecified;
            }
            set
            {
                this.itemSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSupport
    {

        private int supportId;

        private bool supportIdSpecified;

        private int conductorCount;

        private bool conductorCountSpecified;

        private int axisCount;

        private bool axisCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SupportId
        {
            get
            {
                return this.supportId;
            }
            set
            {
                this.supportId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SupportIdSpecified
        {
            get
            {
                return this.supportIdSpecified;
            }
            set
            {
                this.supportIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ConductorCount
        {
            get
            {
                return this.conductorCount;
            }
            set
            {
                this.conductorCount = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ConductorCountSpecified
        {
            get
            {
                return this.conductorCountSpecified;
            }
            set
            {
                this.conductorCountSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int AxisCount
        {
            get
            {
                return this.axisCount;
            }
            set
            {
                this.axisCount = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AxisCountSpecified
        {
            get
            {
                return this.axisCountSpecified;
            }
            set
            {
                this.axisCountSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetTax
    {

        private string taxId;

        private string value;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TaxId
        {
            get
            {
                return this.taxId;
            }
            set
            {
                this.taxId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestFilteredRefBook
    {

        private string classifierName;

        private int filter;

        private bool filterSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ClassifierName
        {
            get
            {
                return this.classifierName;
            }
            set
            {
                this.classifierName = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FilterSpecified
        {
            get
            {
                return this.filterSpecified;
            }
            set
            {
                this.filterSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSpecialTariff
    {

        private bool value;

        private bool valueSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValueSpecified
        {
            get
            {
                return this.valueSpecified;
            }
            set
            {
                this.valueSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestKIT
    {

        private int land;

        private bool landSpecified;

        private int road_Rus;

        private bool road_RusSpecified;

        private int direction;

        private bool directionSpecified;

        private int kIT_ID;

        private bool kIT_IDSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Land
        {
            get
            {
                return this.land;
            }
            set
            {
                this.land = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandSpecified
        {
            get
            {
                return this.landSpecified;
            }
            set
            {
                this.landSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Road_Rus
        {
            get
            {
                return this.road_Rus;
            }
            set
            {
                this.road_Rus = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Road_RusSpecified
        {
            get
            {
                return this.road_RusSpecified;
            }
            set
            {
                this.road_RusSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DirectionSpecified
        {
            get
            {
                return this.directionSpecified;
            }
            set
            {
                this.directionSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int KIT_ID
        {
            get
            {
                return this.kIT_ID;
            }
            set
            {
                this.kIT_ID = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KIT_IDSpecified
        {
            get
            {
                return this.kIT_IDSpecified;
            }
            set
            {
                this.kIT_IDSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestRur2Usd
    {

        private double rate;

        private bool rateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Rate
        {
            get
            {
                return this.rate;
            }
            set
            {
                this.rate = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RateSpecified
        {
            get
            {
                return this.rateSpecified;
            }
            set
            {
                this.rateSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetLandCurrency
    {

        private int landId;

        private bool landIdSpecified;

        private int currencyId;

        private bool currencyIdSpecified;

        private int directionId;

        private bool directionIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CurrencyId
        {
            get
            {
                return this.currencyId;
            }
            set
            {
                this.currencyId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyIdSpecified
        {
            get
            {
                return this.currencyIdSpecified;
            }
            set
            {
                this.currencyIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int DirectionId
        {
            get
            {
                return this.directionId;
            }
            set
            {
                this.directionId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DirectionIdSpecified
        {
            get
            {
                return this.directionIdSpecified;
            }
            set
            {
                this.directionIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetCommonCurrency
    {

        private int currencyId;

        private bool currencyIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CurrencyId
        {
            get
            {
                return this.currencyId;
            }
            set
            {
                this.currencyId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CurrencyIdSpecified
        {
            get
            {
                return this.currencyIdSpecified;
            }
            set
            {
                this.currencyIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestOnDate
    {

        private System.DateTime onDate;

        private bool onDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime OnDate
        {
            get
            {
                return this.onDate;
            }
            set
            {
                this.onDate = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OnDateSpecified
        {
            get
            {
                return this.onDateSpecified;
            }
            set
            {
                this.onDateSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestFromStation
    {

        private string code;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestToStation
    {

        private string code;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetReadressingStation
    {

        private string code;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetDispStation
    {

        private string code;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetWashingStation
    {

        private string code;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetUncouplingStation
    {

        private string code;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetRepairStation
    {

        private string code;

        private int landId;

        private bool landIdSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LandIdSpecified
        {
            get
            {
                return this.landIdSpecified;
            }
            set
            {
                this.landIdSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestSetRate
    {

        private int fromCurrency;

        private bool fromCurrencySpecified;

        private int toCurrency;

        private bool toCurrencySpecified;

        private double rate;

        private bool rateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int FromCurrency
        {
            get
            {
                return this.fromCurrency;
            }
            set
            {
                this.fromCurrency = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FromCurrencySpecified
        {
            get
            {
                return this.fromCurrencySpecified;
            }
            set
            {
                this.fromCurrencySpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ToCurrency
        {
            get
            {
                return this.toCurrency;
            }
            set
            {
                this.toCurrency = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToCurrencySpecified
        {
            get
            {
                return this.toCurrencySpecified;
            }
            set
            {
                this.toCurrencySpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Rate
        {
            get
            {
                return this.rate;
            }
            set
            {
                this.rate = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RateSpecified
        {
            get
            {
                return this.rateSpecified;
            }
            set
            {
                this.rateSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestLoadRateFromSite
    {

        private bool value;

        public RequestLoadRateFromSite()
        {
            this.value = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestThruRoutes
    {

        private string code;

        private string landId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LandId
        {
            get
            {
                return this.landId;
            }
            set
            {
                this.landId = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestWagon
    {

        private int transpId;

        private bool transpIdSpecified;

        private int ownerId;

        private bool ownerIdSpecified;

        private int count;

        private bool countSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TranspId
        {
            get
            {
                return this.transpId;
            }
            set
            {
                this.transpId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TranspIdSpecified
        {
            get
            {
                return this.transpIdSpecified;
            }
            set
            {
                this.transpIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
            set
            {
                this.ownerId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnerIdSpecified
        {
            get
            {
                return this.ownerIdSpecified;
            }
            set
            {
                this.ownerIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified
        {
            get
            {
                return this.countSpecified;
            }
            set
            {
                this.countSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestEmptyWagon
    {

        private int transpId;

        private bool transpIdSpecified;

        private int ownerId;

        private bool ownerIdSpecified;

        private int count;

        private bool countSpecified;

        private string fromCargoCode;

        private int axis;

        private bool axisSpecified;

        private double tareWeight;

        private bool tareWeightSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TranspId
        {
            get
            {
                return this.transpId;
            }
            set
            {
                this.transpId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TranspIdSpecified
        {
            get
            {
                return this.transpIdSpecified;
            }
            set
            {
                this.transpIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
            set
            {
                this.ownerId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnerIdSpecified
        {
            get
            {
                return this.ownerIdSpecified;
            }
            set
            {
                this.ownerIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified
        {
            get
            {
                return this.countSpecified;
            }
            set
            {
                this.countSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FromCargoCode
        {
            get
            {
                return this.fromCargoCode;
            }
            set
            {
                this.fromCargoCode = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Axis
        {
            get
            {
                return this.axis;
            }
            set
            {
                this.axis = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AxisSpecified
        {
            get
            {
                return this.axisSpecified;
            }
            set
            {
                this.axisSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double TareWeight
        {
            get
            {
                return this.tareWeight;
            }
            set
            {
                this.tareWeight = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TareWeightSpecified
        {
            get
            {
                return this.tareWeightSpecified;
            }
            set
            {
                this.tareWeightSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestRefWagon
    {

        private int ownerId;

        private bool ownerIdSpecified;

        private int fullCount;

        private bool fullCountSpecified;

        private int emptyCount;

        private bool emptyCountSpecified;

        private int sectionSize;

        private bool sectionSizeSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
            set
            {
                this.ownerId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnerIdSpecified
        {
            get
            {
                return this.ownerIdSpecified;
            }
            set
            {
                this.ownerIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int FullCount
        {
            get
            {
                return this.fullCount;
            }
            set
            {
                this.fullCount = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FullCountSpecified
        {
            get
            {
                return this.fullCountSpecified;
            }
            set
            {
                this.fullCountSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int EmptyCount
        {
            get
            {
                return this.emptyCount;
            }
            set
            {
                this.emptyCount = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EmptyCountSpecified
        {
            get
            {
                return this.emptyCountSpecified;
            }
            set
            {
                this.emptyCountSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SectionSize
        {
            get
            {
                return this.sectionSize;
            }
            set
            {
                this.sectionSize = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SectionSizeSpecified
        {
            get
            {
                return this.sectionSizeSpecified;
            }
            set
            {
                this.sectionSizeSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestContainer
    {

        private int transpID;

        private bool transpIDSpecified;

        private int ownerId;

        private bool ownerIdSpecified;

        private int contCount;

        private bool contCountSpecified;

        private string tareWeight;

        private string special;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TranspID
        {
            get
            {
                return this.transpID;
            }
            set
            {
                this.transpID = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TranspIDSpecified
        {
            get
            {
                return this.transpIDSpecified;
            }
            set
            {
                this.transpIDSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
            set
            {
                this.ownerId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnerIdSpecified
        {
            get
            {
                return this.ownerIdSpecified;
            }
            set
            {
                this.ownerIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ContCount
        {
            get
            {
                return this.contCount;
            }
            set
            {
                this.contCount = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ContCountSpecified
        {
            get
            {
                return this.contCountSpecified;
            }
            set
            {
                this.contCountSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TareWeight
        {
            get
            {
                return this.tareWeight;
            }
            set
            {
                this.tareWeight = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Special
        {
            get
            {
                return this.special;
            }
            set
            {
                this.special = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestContainerTransport
    {

        private int transpID;

        private bool transpIDSpecified;

        private int ownerId;

        private bool ownerIdSpecified;

        private int count;

        private bool countSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TranspID
        {
            get
            {
                return this.transpID;
            }
            set
            {
                this.transpID = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TranspIDSpecified
        {
            get
            {
                return this.transpIDSpecified;
            }
            set
            {
                this.transpIDSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
            set
            {
                this.ownerId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnerIdSpecified
        {
            get
            {
                return this.ownerIdSpecified;
            }
            set
            {
                this.ownerIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified
        {
            get
            {
                return this.countSpecified;
            }
            set
            {
                this.countSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/PostSchema.xsd")]
    public partial class RequestContainerTransportKRK
    {

        private int transpID;

        private bool transpIDSpecified;

        private int ownerId;

        private bool ownerIdSpecified;

        private int count;

        private bool countSpecified;

        private int ownerId_DGV;

        private bool ownerId_DGVSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TranspID
        {
            get
            {
                return this.transpID;
            }
            set
            {
                this.transpID = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TranspIDSpecified
        {
            get
            {
                return this.transpIDSpecified;
            }
            set
            {
                this.transpIDSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int OwnerId
        {
            get
            {
                return this.ownerId;
            }
            set
            {
                this.ownerId = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnerIdSpecified
        {
            get
            {
                return this.ownerIdSpecified;
            }
            set
            {
                this.ownerIdSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CountSpecified
        {
            get
            {
                return this.countSpecified;
            }
            set
            {
                this.countSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int OwnerId_DGV
        {
            get
            {
                return this.ownerId_DGV;
            }
            set
            {
                this.ownerId_DGV = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnerId_DGVSpecified
        {
            get
            {
                return this.ownerId_DGVSpecified;
            }
            set
            {
                this.ownerId_DGVSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/ResultSchema.xsd")]
    public partial class ResultKIT
    {

        private string kIT_ID;

        private string description;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string KIT_ID
        {
            get
            {
                return this.kIT_ID;
            }
            set
            {
                this.kIT_ID = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/ResultSchema.xsd")]
    public partial class ResultParameter
    {

        private string name;

        private string value;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
