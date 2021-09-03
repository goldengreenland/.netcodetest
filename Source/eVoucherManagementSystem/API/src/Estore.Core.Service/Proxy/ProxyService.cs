using Estore.Core.Entities.Const;
using Estore.Core.Entities.Dtos;
using Estore.Core.Entities.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Estore.Core.Service.Proxy
{
    public class ProxyService : IProxyService
    {
        #region Variables
        private readonly string _username = "pcmsAdmin";
        private readonly string _password = "pcms@codigo";
        private readonly string key = "P@ssword!2@#$%^21";
        private readonly ICoreProxy _coreProxy;

        #endregion Variables

        #region Constructor

        public ProxyService(ICoreProxy coreProxy)
        {
            _coreProxy = coreProxy;
        }

        #endregion Constructor

        #region Public Method
        public async Task<IEnumerable<PromoCode>> GetUnusedEVoucherAsync()
        {
            string token = GenerateToken(_username, _password);
            List<PromoCode> promoCodes = new List<PromoCode>();
            string Url = _coreProxy.GetURL(ApiModule.PromoCode, ApiMethod.GetUnusedEVoucher);
            HttpClient<string, List<PromoCode>> _sslPost = new HttpClient<string, List<PromoCode>>(string.Empty);
            promoCodes = await _sslPost.Get(string.Empty, _coreProxy.GetCredentialsInfo(Url, token));
            return promoCodes;
        }

        public async Task<IEnumerable<PromoCode>> GetUsedEVoucherAsync()
        {
            string token = GenerateToken(_username, _password);
            List<PromoCode> promoCodes = new List<PromoCode>();
            string Url = _coreProxy.GetURL(ApiModule.PromoCode, ApiMethod.GetUsedEVoucher);
            HttpClient<string, List<PromoCode>> _sslPost = new HttpClient<string, List<PromoCode>>(string.Empty);
            promoCodes = await _sslPost.Get(string.Empty, _coreProxy.GetCredentialsInfo(Url, token));
            return promoCodes;
        }

        public async Task<PromoCodeVerifyResponse> VerifyPromoCodeAsync(string promoCode)
        {
            string token = GenerateToken(_username, _password);
            PromoCodeVerifyResponse promoCodeVerifyResponse = new PromoCodeVerifyResponse();
            var queryParams = new NameValueCollection()
            {
                { "promoCode", promoCode.ToString() }
            };

            string Url = _coreProxy.GetURL(ApiModule.PromoCode, ApiMethod.Verify);
            string strRequest = _coreProxy.GetQueryString(queryParams);
            HttpClient<string, PromoCodeVerifyResponse> _sslPost = new HttpClient<string, PromoCodeVerifyResponse>(strRequest);
            promoCodeVerifyResponse = await _sslPost.Post(strRequest, _coreProxy.GetCredentialsInfo(Url, token));

            return promoCodeVerifyResponse;
        }
        #endregion

        #region Private Method
        public string GenerateToken(string username, string password)
        {
            if (!(username.Equals(_username) || password.Equals(_password)))
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
