using System;

namespace PishgamRayan
{
    public class MessageResponse
    {
        /// <summary>
        /// پیام های بازگشتی
        /// </summary>
        public ReceiveMessage[] result { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string message { get; set; }
    }

    public class ReceiveMessage
    {
        /// <summary>
        /// شماره دریافت کننده
        /// </summary>
        public string PrivateNumber { get; set; }

        /// <summary>
        /// زمان
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// اپراتور
        /// </summary>
        public byte OperatorType { get; set; }

        /// <summary>
        /// شماره ارسال کننده
        /// </summary>
        public string SenderNumber { get; set; }

        /// <summary>
        /// متن پیام
        /// </summary>
        public string Message { get; set; }
    }
}
