// See https://aka.ms/new-console-template for more information
using PishgamRayan;

Console.WriteLine("Sample Code");
//ارسال
const string ApiKey = "01842D5D269BA322C5B22497A17A48AA0647FD1BC39494DF492EC3CB56ED75358B7532311F0D8547A29875D70E79B93DF1344FF3D9E67D7947A0CBF3DD2F23642073C9A6738581128BA2A7076499FC05";
SendRequest sendRequest = new SendRequest()
{
    messageBodies = new List<string> { "ارسال تست" },
    encodings = 16,
    recipientNumbers = new List<string> { "989120248149" } , //989*********
    senderNumber = "500032129", //50003****
    userTag = ""
};
await PishgamRayanSender.SendSmsAsync(sendRequest, ApiKey);
//Console.WriteLine("SendAsync",await PishgamRayanSender.SendSmsAsync(re));
//دریافت وضعیت
//var statusRequest = new StatusRequest()
//{
//    MessageIds = new long[234564] //--array_of_messageIds--
//};
//await PishgamRayanSender.GetStatusesAsync(statusRequest,ApiKey);

////موجودی
//await PishgamRayanSender.GetCreditAsync(ApiKey);

////دریافت پیام
//var messageRequest = new MessageRequest()
//{
//    MarkAsRead = false,
//    //همه پاراکترها اختیاری است
//};
//await PishgamRayanSender.GetMessagesAsync(messageRequest,ApiKey);
Console.ReadKey();