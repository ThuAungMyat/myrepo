using System;
using System.Collections.Generic;

namespace SampleWeb.Models
{
    public partial class tbMovieSeatBooking
    {
        public int ID { get; set; }
        public string VoucherCode { get; set; }
        public string SeatID { get; set; }
        public string SeatNumber { get; set; }
        public Nullable<int> TheatreId { get; set; }
        public string TheatreName { get; set; }
        public Nullable<int> CinemaId { get; set; }
        public string CinemaName { get; set; }
        public Nullable<decimal> TicketFees { get; set; }
        public Nullable<decimal> ServiceFees { get; set; }
        public Nullable<decimal> ConvenientFees { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Accesstime { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> HoldingTime { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public string SeatType { get; set; }
        public Nullable<bool> IsCheckedout { get; set; }
        public Nullable<System.DateTime> CheckedOutTime { get; set; }
        public string CheckOutType { get; set; }
        public Nullable<System.DateTime> Showtime { get; set; }
        public Nullable<int> MovieId { get; set; }
        public string MovieTitle { get; set; }
        public Nullable<decimal> TotalFees { get; set; }
        public Nullable<bool> IsRedeemed { get; set; }
        public Nullable<System.DateTime> RedeemedAt { get; set; }
        public string PaymentCode { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public Nullable<bool> IsUsed { get; set; }
        public string ConnectionID { get; set; }
        public Nullable<System.DateTime> UsedAt { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupName { get; set; }
        public string PaidBy { get; set; }
        public Nullable<System.DateTime> PaidAt { get; set; }
        public Nullable<decimal> ExtraCharge { get; set; }
        public string BookingId { get; set; }
        public Nullable<bool> IsRefunded { get; set; }
        public Nullable<System.DateTime> RefundedDate { get; set; }
        public Nullable<bool> IsBooked { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string ReprintInfo { get; set; }
        public Nullable<bool> IsSelfTicketing { get; set; }
        public Nullable<System.DateTime> SelfTicketingTime { get; set; }
        public Nullable<System.Guid> UniqueID { get; set; }
        public Nullable<System.Guid> MovieGUID { get; set; }
        public Nullable<bool> IsSynced { get; set; }
    }
}
