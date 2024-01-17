using System;

namespace PishgamRayan
{
    public class MessageRequest
    {
        /// <summary>
        /// شماره ارسال کننده (پیش فرض همه شماره ها)
        /// </summary>
        public string PrivateNumber { get; set; }

        /// <summary>
        /// زمان شروع (پیش فرض 24 ساعت گذشته)
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تعداد پیام ها (پیش فرض 100)
        /// </summary>
        public int? NumberOfMessages { get; set; }

        /// <summary>
        /// علامت گذاری به عنوان خوانده شده (پیش فرض true)
        /// </summary>
        public bool? MarkAsRead { get; set; }
    }
}
