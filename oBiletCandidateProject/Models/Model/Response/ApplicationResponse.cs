using DataModels.Constants;
using System.Text.Json.Serialization;

namespace DataModels.Model.Response
{
    public class ApplicationResponse<T> : ApiResponse
    {
        [JsonPropertyName("responseCode")]
        public string ResponseCode { get; set; }
        [JsonPropertyName("responseMessage")]
        public string ResponseMessage { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }

        public void SetSuccess(string Code, string Message)
        {
            this.ResponseCode = Code;
            this.ResponseMessage = Message;
        }
        public void SetBusinessError(string Message)
        {
            this.ResponseCode = GeneralConstant.BusinessErrorCode;
            this.Message = string.Format(GeneralConstant.BusinessErrorMessage, Message);
        }
        public void SetTechnicalError(string Message)
        {
            this.ResponseMessage = GeneralConstant.TechnicalErrorCode;
            this.Message = string.Format(GeneralConstant.TechnicalErrorMessage, Message);
        }
    }
}
