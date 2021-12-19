using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangPhanTan.DTO
{
    public class ExchangeTransaction
    {
        private double initBalance;
        private double remainBalance;
        private BindingList<ExchangeEndpoint> endpoints;

        public ExchangeTransaction()
        {
            endpoints = new BindingList<ExchangeEndpoint>();
        }

        public double InitBalance { get => initBalance; set => remainBalance = initBalance = value; }
        public double RemainBalance { get => remainBalance; set => remainBalance = value; }
        public BindingList<ExchangeEndpoint> Endpoints { get => endpoints; set => endpoints = value; }

        public void Clear()
        {
            this.remainBalance = this.initBalance;
            this.endpoints.Clear();
        }

        public bool IsAvailable()
        {
            return this.endpoints.Count > 0;
        }

        public void RemoveEndpoint(int idx)
        {
            try
            {
                this.endpoints.RemoveAt(idx);
                UpdateRemainBalance();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateRemainBalance()
        {
            remainBalance = initBalance;
            foreach (var item in endpoints)
            {
                remainBalance -= item.ExchangeMoney;
            }
            if (RemainBalance < 0)
                throw new Exception("Số dư TK chuyển không đủ");
        }

        /// <summary>
        /// Add a new endpoint with 'zero' money, no need to update remain balance
        /// </summary>
        /// <param name="endpoint"></param>
        public void AddEnpoint(ExchangeEndpoint endpoint)
        {
            if (endpoint == null)
                throw new ArgumentNullException();
            endpoints.Add(endpoint);
        }
    }
}
