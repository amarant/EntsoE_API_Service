using System;
using System.Collections.Generic;
using System.Text;

namespace EntsoE_DataModel
{
    public class GenerationForecast
    {
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0", IsNullable = false)]
    public partial class GL_MarketDocument
    {

        private string mRIDField;

        private int revisionNumberField;

        private string typeField;

        private string ProcessTypeField;

        private GL_MarketDocumentSender_MarketParticipantmRID sender_MarketParticipantmRIDField;

        private string sender_MarketParticipantmarketRoletypeField;

        private GL_MarketDocumentReceiver_MarketParticipantmRID receiver_MarketParticipantmRIDField;

        private string receiver_MarketParticipantmarketRoletypeField;

        private System.DateTime createdDateTimeField;

        private GL_MarketDocumentTime_PeriodtimeInterval time_PeriodtimeIntervalField;

        private GL_MarketDocumentTimeSeries[] timeSeriesField;

        /// <remarks/>
        public string mRID
        {
            get
            {
                return this.mRIDField;
            }
            set
            {
                this.mRIDField = value;
            }
        }

        /// <remarks/>
        public int revisionNumber
        {
            get
            {
                return this.revisionNumberField;
            }
            set
            {
                this.revisionNumberField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("process.processType")]
        public string ProcessType
        {
            get
            {
                return this.ProcessTypeField;
            }
            set
            {
                this.ProcessTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sender_MarketParticipant.mRID")]
        public GL_MarketDocumentSender_MarketParticipantmRID Sender_MarketParticipantmRID
        {
            get
            {
                return this.sender_MarketParticipantmRIDField;
            }
            set
            {
                this.sender_MarketParticipantmRIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sender_MarketParticipant.marketRole.type")]
        public string Sender_MarketParticipantmarketRoletype
        {
            get
            {
                return this.sender_MarketParticipantmarketRoletypeField;
            }
            set
            {
                this.sender_MarketParticipantmarketRoletypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("receiver_MarketParticipant.mRID")]
        public GL_MarketDocumentReceiver_MarketParticipantmRID Receiver_MarketParticipantmRID
        {
            get
            {
                return this.receiver_MarketParticipantmRIDField;
            }
            set
            {
                this.receiver_MarketParticipantmRIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("receiver_MarketParticipant.marketRole.type")]
        public string Receiver_MarketParticipantmarketRoletype
        {
            get
            {
                return this.receiver_MarketParticipantmarketRoletypeField;
            }
            set
            {
                this.receiver_MarketParticipantmarketRoletypeField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CreatedDateTime
        {
            get
            {
                return this.createdDateTimeField;
            }
            set
            {
                this.createdDateTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("time_Period.timeInterval")]
        public GL_MarketDocumentTime_PeriodtimeInterval Time_PeriodtimeInterval
        {
            get
            {
                return this.time_PeriodtimeIntervalField;
            }
            set
            {
                this.time_PeriodtimeIntervalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TimeSeries")]
        public GL_MarketDocumentTimeSeries[] TimeSeries
        {
            get
            {
                return this.timeSeriesField;
            }
            set
            {
                this.timeSeriesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentSender_MarketParticipantmRID
    {

        private string codingSchemeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodingScheme
        {
            get
            {
                return this.codingSchemeField;
            }
            set
            {
                this.codingSchemeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentReceiver_MarketParticipantmRID
    {

        private string codingSchemeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodingScheme
        {
            get
            {
                return this.codingSchemeField;
            }
            set
            {
                this.codingSchemeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentTime_PeriodtimeInterval
    {

        private string startField;

        private string endField;

        /// <remarks/>
        public string Start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }

        /// <remarks/>
        public string End
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentTimeSeries
    {

        private int mRIDField;

        private string businessTypeField;

        private string objectAggregationField;

        private GL_MarketDocumentTimeSeriesInBiddingZone_DomainmRID inBiddingZone_DomainmRIDField;

        private string quantity_Measure_UnitnameField;

        private string curveTypeField;

        private GL_MarketDocumentTimeSeriesPeriod periodField;

        /// <remarks/>
        public int mRID
        {
            get
            {
                return this.mRIDField;
            }
            set
            {
                this.mRIDField = value;
            }
        }

        /// <remarks/>
        public string businessType
        {
            get
            {
                return this.businessTypeField;
            }
            set
            {
                this.businessTypeField = value;
            }
        }

        /// <remarks/>
        public string objectAggregation
        {
            get
            {
                return this.objectAggregationField;
            }
            set
            {
                this.objectAggregationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("inBiddingZone_Domain.mRID")]
        public GL_MarketDocumentTimeSeriesInBiddingZone_DomainmRID inBiddingZone_DomainmRID
        {
            get
            {
                return this.inBiddingZone_DomainmRIDField;
            }
            set
            {
                this.inBiddingZone_DomainmRIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("quantity_Measure_Unit.name")]
        public string quantity_Measure_Unitname
        {
            get
            {
                return this.quantity_Measure_UnitnameField;
            }
            set
            {
                this.quantity_Measure_UnitnameField = value;
            }
        }

        /// <remarks/>
        public string curveType
        {
            get
            {
                return this.curveTypeField;
            }
            set
            {
                this.curveTypeField = value;
            }
        }

        /// <remarks/>
        public GL_MarketDocumentTimeSeriesPeriod Period
        {
            get
            {
                return this.periodField;
            }
            set
            {
                this.periodField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentTimeSeriesInBiddingZone_DomainmRID
    {

        private string codingSchemeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string codingScheme
        {
            get
            {
                return this.codingSchemeField;
            }
            set
            {
                this.codingSchemeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentTimeSeriesPeriod
    {

        private GL_MarketDocumentTimeSeriesPeriodTimeInterval timeIntervalField;

        private string resolutionField;

        private GL_MarketDocumentTimeSeriesPeriodPoint[] pointField;

        /// <remarks/>
        public GL_MarketDocumentTimeSeriesPeriodTimeInterval timeInterval
        {
            get
            {
                return this.timeIntervalField;
            }
            set
            {
                this.timeIntervalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "duration")]
        public string resolution
        {
            get
            {
                return this.resolutionField;
            }
            set
            {
                this.resolutionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Point")]
        public GL_MarketDocumentTimeSeriesPeriodPoint[] Point
        {
            get
            {
                return this.pointField;
            }
            set
            {
                this.pointField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentTimeSeriesPeriodTimeInterval
    {

        private string startField;

        private string endField;

        /// <remarks/>
        public string start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }

        /// <remarks/>
        public string end
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-6:generationloaddocument:3:0")]
    public partial class GL_MarketDocumentTimeSeriesPeriodPoint
    {

        private int positionField;

        private int quantityField;

        /// <remarks/>
        public int position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        public int quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }
    }


}
