using DevExpress.Xpo;


namespace ConsoleApplication1 {

    public class Customer : XPObject {
        public Customer(Session session) : base(session) { }
        string _CompanyName;
        public string CompanyName {
            get { return _CompanyName; }
            set { SetPropertyValue("CompanyName", ref _CompanyName, value); }
        }
        string _CompanyAddress;
        public string CompanyAddress {
            get { return _CompanyAddress; }
            set { SetPropertyValue("CompanyAddress", ref _CompanyAddress, value); }
        }
        string _ContactName;
        public string ContactName {
            get { return _ContactName; }
            set { SetPropertyValue("ContactName", ref _ContactName, value); }
        }
        string _Country;
        public string Country {
            get { return _Country; }
            set { SetPropertyValue("Country", ref _Country, value); }
        }
        string _Phone;
        public string Phone {
            get { return _Phone; }
            set { SetPropertyValue("Phone", ref _Phone, value); }
        }
    }

}
