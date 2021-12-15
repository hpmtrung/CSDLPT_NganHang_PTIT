using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace NganHangPhanTan.DTO
{
    public class ExchangeEndpoint : INotifyPropertyChanged
    {
        public static readonly int ACCOUNT_ID_IDX = 0;
        public static readonly int FULLNAME_IDX = 1;
        public static readonly int CUSTOMER_ID_IDX = 2;
        public static readonly int EXCHANGE_MONEY_IDX = 3;

        private string accountId;
        private string customerFullname;
        private string customerId;
        private double exchangeMoney;

        public ExchangeEndpoint()
        {}

        public ExchangeEndpoint(string accountId, string customerFullname, string customerId, double exchangeMoney)
        {
            AccountId = accountId;
            CustomerFullname = customerFullname;
            CustomerId = customerId;
            ExchangeMoney = exchangeMoney;
        }

        [DisplayName("Số TK")]
        public string AccountId { 
            get => accountId; 
            set {
                if (accountId != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException();
                    accountId = value;
                    OnPropertyChanged();
                }
            }
        }

        [DisplayName("Họ tên KH")]
        public string CustomerFullname { 
            get => customerFullname; 
            set
            {
                if (customerFullname != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException();
                    customerFullname = value;
                    OnPropertyChanged();
                }
            }
        }

        [DisplayName("Số CMND")]
        public string CustomerId { 
            get => customerId;
            set
            {
                if (customerId != value)
                {
                    if (string.IsNullOrEmpty(value))
                        throw new ArgumentException();
                    customerId = value;
                    OnPropertyChanged();
                }
            }
        }

        [DisplayName("Số tiền chuyển")]
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString="c0")]
        public double ExchangeMoney { 
            get => exchangeMoney;
            set
            {
                if (exchangeMoney != value)
                {
                    if (value < 0)
                        throw new ArgumentException("Số tiền chuyển không hợp lệ");
                    exchangeMoney = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
