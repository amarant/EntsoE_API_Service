using System;
using System.Collections.Generic;
using System.Text;

namespace EntsoE_DataModel
{
    public class ApiAckResponse
    {
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-1:acknowledgementdocument:7:0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:iec62325.351:tc57wg16:451-1:acknowledgementdocument:7:0", IsNullable = false)]
    public partial class Acknowledgement_MarketDocument
    {

        private string mRIDField;

        private System.DateTime createdDateTimeField;

        private Acknowledgement_MarketDocumentSender_MarketParticipantmRID sender_MarketParticipantmRIDField;

        private string sender_MarketParticipantmarketRoletypeField;

        private Acknowledgement_MarketDocumentReceiver_MarketParticipantmRID receiver_MarketParticipantmRIDField;

        private string receiver_MarketParticipantmarketRoletypeField;

        private System.DateTime received_MarketDocumentcreatedDateTimeField;

        private Acknowledgement_MarketDocumentReason reasonField;

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
        public System.DateTime createdDateTime
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
        [System.Xml.Serialization.XmlElementAttribute("sender_MarketParticipant.mRID")]
        public Acknowledgement_MarketDocumentSender_MarketParticipantmRID sender_MarketParticipantmRID
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
        public string sender_MarketParticipantmarketRoletype
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
        public Acknowledgement_MarketDocumentReceiver_MarketParticipantmRID receiver_MarketParticipantmRID
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
        public string receiver_MarketParticipantmarketRoletype
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
        [System.Xml.Serialization.XmlElementAttribute("received_MarketDocument.createdDateTime")]
        public System.DateTime received_MarketDocumentcreatedDateTime
        {
            get
            {
                return this.received_MarketDocumentcreatedDateTimeField;
            }
            set
            {
                this.received_MarketDocumentcreatedDateTimeField = value;
            }
        }

        /// <remarks/>
        public Acknowledgement_MarketDocumentReason Reason
        {
            get
            {
                return this.reasonField;
            }
            set
            {
                this.reasonField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-1:acknowledgementdocument:7:0")]
    public partial class Acknowledgement_MarketDocumentSender_MarketParticipantmRID
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-1:acknowledgementdocument:7:0")]
    public partial class Acknowledgement_MarketDocumentReceiver_MarketParticipantmRID
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:iec62325.351:tc57wg16:451-1:acknowledgementdocument:7:0")]
    public partial class Acknowledgement_MarketDocumentReason
    {

        private ushort codeField;

        private string textField;

        /// <remarks/>
        public ushort code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }


}
