using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PishgamRayan
{
    public class SendRequest
    {
        /// <summary>
        /// متن پیام
        /// </summary>
        [Required]
        public List<string>  messageBodies { get; set; }

        /// <summary>
        /// شماره دریافت کننده
        /// </summary>
        [Required]
        public List<string> recipientNumbers { get; set; }

        /// <summary>
        /// شماره ارسال کننده
        /// </summary>
        [Required]
        public string senderNumber { get; set; }

        /// <summary>
        /// کدینگ پیام
        /// <br/>2- باینری در قالب رشته کد
        /// <br/>7- انگلیسی
        /// <br/>8- کاراکتر و یا بایت 8 بیتی
        /// <br/>16- فارسی
        /// </summary>
        public byte encodings { get; set; }

        /// <summary>
        /// برچسب ارسال
        /// </summary>
        [MaxLength(40)]
        public string userTag { get; set; }
    }
}
