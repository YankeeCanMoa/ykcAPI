namespace ykcAPI.Models
{
    /// <summary>
    /// Response 값
    /// </summary>
    /// <remarks>
    /// remarks 비고스
    /// </remarks>
    /// <typeparam name="T">반환 Data DTO</typeparam>
    public class CusTomResponse<T>
    {
        /// <summary>
        /// 결과코드(OK:200, 401:NotFound, 500:Error...)
        /// </summary>
        public int code { get; set; } = 200;

        /// <summary>
        /// 결과메세지(200:"ok" ..)
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 결과값 Data(200 응답 외에 Null)
        /// </summary>
        public T data { get; set; }
    }
}
