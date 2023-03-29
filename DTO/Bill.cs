using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DTO
{
    public class Bill
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private DateTime? datecheckin;
        public DateTime? DateCheckIn
        {
            get { return datecheckin; }
            set { datecheckin = value; }
        }
        private DateTime? datecheckout;
        public DateTime? DateCheckOut
        {
            get { return datecheckout; }
            set { datecheckout = value; }
        }
        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public Bill(int id, DateTime? checkin, DateTime? datecheckout, int status)
        {
            this.ID = id;   
            this.DateCheckIn= checkin;
            this.DateCheckOut= datecheckout;
            this.Status= status;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckin"];
            var checkout = row["dateCheckout"];
            if(checkout.ToString() != "") 
                 this.DateCheckOut = (DateTime?)checkout;
            this.Status = (int)row["status"];

        }
    }
}
