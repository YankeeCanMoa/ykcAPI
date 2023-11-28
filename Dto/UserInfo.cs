using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ykcAPI.Dto
{
    /// <summary>
    /// 유저 정보 Array(Input Values)
    /// </summary>
    public class UserInfoList
    {
        /// <summary>
        /// 유저정보 List
        /// </summary>
        [Required(ErrorMessage = "유저 정보를 입력하세요.")]
        public List<UserInfo> UserInfos { get; set; }
    }
    /// <summary>
    /// 유저 정보
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 이름
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// 나이
        /// </summary>
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        /// <summary>
        /// 휴대폰번호
        /// </summary>
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
    }

    /// <summary>
    /// 반환 DTO
    /// </summary>
    public class UserID
    {
        /// <summary>
        /// 유저아이디(이름+나이+전화번호)
        /// </summary>
        public string Userid { get; set; }
    }
}
