using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ykcAPI.Dto;
using ykcAPI.Models;

namespace ykcAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 유저정보들을 입력받으면 User ID를 생성하여 Return함
        /// </summary>
        /// <remarks>
        /// 유저 ID를 생성해주는 API입니다.
        /// </remarks>
        /// <param name="userInfoList">유저정보 입력</param>
        /// <returns>
        /// </returns>
        [HttpPost("GetProfiles")]
        [ProducesResponseType(typeof(CusTomResponse<List<UserID>>), 200)]
        public IActionResult Post([FromBody] UserInfoList userInfoList)
        {
            try
            {
                if (userInfoList == null)
                {
                    return BadRequest(new CusTomResponse<List<UserID>>
                    {
                        code = (int)HttpStatusCode.BadRequest,
                        message = "Bad Request: No data provided in the request body."
                    });
                }

                // 데이터 처리 로직: UserInfo List를 이용하여 Profile List 생성
                List<UserID> profileList = userInfoList.UserInfos.Select(user => new UserID
                {
                    Userid = user.Name + user.Age + user.Phone
                }).ToList();

                // 성공적인 응답
                CusTomResponse<List<UserID>> response = new CusTomResponse<List<UserID>>
                {
                    code = (int)HttpStatusCode.OK,
                    message = "ok",
                    data = profileList
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // 성공적인 응답
                CusTomResponse<List<UserID>> errorResponse = new CusTomResponse<List<UserID>>
                {
                    code = (int)HttpStatusCode.InternalServerError,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string parameter)
        {
            // GET 요청 처리 로직
            return Ok($"Received GET request with parameter: {parameter}");
        }

        [HttpPut]
        public IActionResult Put([FromBody] PutDataModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data format.");
            }

            // PUT 요청 처리 로직
            return Ok($"Received PUT data: {model.Data}");
        }

        [HttpDelete("api/items/{id}")]
        public IActionResult DeleteItem(int id)
        {
            // ID를 사용하여 아이템 삭제 로직
            // ...

            return Ok($"Deleted item with ID: {id}");
        }
    }

    public class PutDataModel
    {
        public string Data { get; set; }
    }

}
