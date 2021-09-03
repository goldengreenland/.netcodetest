using Pcms.Core.Entities.Const;
using Pcms.Core.Entities.Dtos;
using Pcms.Core.Entities.Entities;
using Pcms.Core.Entities.Utility;
using Pcms.Core.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pcms.Core.Service
{
    public class PromoCodeService : IPromoCodeService
    {
        #region Private Variable
        private readonly IPromoCodeRepository _promoCodeRepository;
        #endregion

        #region Constructor
        public PromoCodeService(IPromoCodeRepository promoCodeRepository)
        {
            _promoCodeRepository = promoCodeRepository;
        }
        #endregion

        #region Public Method
        public async Task<GeneratePromoCodeResponse> GeneratePromoCodeAsync(GeneratePromoCodeRequest generatePromoCodeRequest)
        {
            GeneratePromoCodeResponse generatePromoCodeResponse = new GeneratePromoCodeResponse();
            try
            {

                if (string.IsNullOrEmpty(generatePromoCodeRequest.Mobile))
                    throw new ArgumentNullException(ErrorMessageConstants.INVALID_MOBILE);

                if (generatePromoCodeRequest.Quantity.Equals(0))
                    throw new ArgumentNullException(ErrorMessageConstants.INVALID_QUANTITY);

                //Generate Code
                for (int i = 0; i < generatePromoCodeRequest.Quantity; i++)
                {
                    PromoCode promoCode = new PromoCode
                    {
                        Promo_Code = KeyGenerator.GetUniqueKey(11),
                        Mobile = generatePromoCodeRequest.Mobile,
                        IsRedeemed = AppConsts.Not_Redeemed,
                        IsUsed = AppConsts.Valid,
                        ExpiryDate = DateTime.Now.AddDays(365),
                        CreatedDate = DateTime.Now
                    };

                    await _promoCodeRepository.Add(promoCode);
                }

                generatePromoCodeResponse.ErrorCode = ErrorCode.Success_Code;
                generatePromoCodeResponse.ErrorMessage = ErrorMessageConstants.SUCCESS;
            }
            catch (ArgumentNullException argex)
            {
                generatePromoCodeResponse.ErrorCode = ErrorCode.Failed_Code;
                generatePromoCodeResponse.ErrorMessage = argex.ParamName.ToString();
            }
            catch (Exception ex)
            {
                generatePromoCodeResponse.ErrorCode = ErrorCode.SystemError_Code;
                generatePromoCodeResponse.ErrorMessage = ex.GetBaseException().ToString();
            }

            return generatePromoCodeResponse;
        }

        public async Task<IEnumerable<PromoCode>> GetAllPromoCodeAsync()
        {
            return (IEnumerable<PromoCode>)await _promoCodeRepository.GetAll();
        }

        public async Task<PromoCodeResponse> GetByPromoCodeAsync(string promoCode)
        {
            PromoCodeResponse promoCodeResponse = new PromoCodeResponse();

            try
            {
                if (string.IsNullOrEmpty(promoCode))
                    throw new ArgumentNullException(ErrorMessageConstants.INVALID_PROMO_CODE);

                PromoCode promoCodes = await _promoCodeRepository.GetByPromoCode(promoCode);
                if (promoCodes != null)
                {
                    promoCodeResponse.IsRedeemed = promoCodes.IsRedeemed;
                    promoCodeResponse.IsUsed = promoCodes.IsUsed;
                    promoCodeResponse.ExpiryDate = promoCodes.ExpiryDate;
                    promoCodeResponse.PromoCode = promoCodes.Promo_Code;
                    promoCodeResponse.QRCodeUrl = promoCodes.QRCodeUrl;

                    promoCodeResponse.ErrorCode = ErrorCode.Success_Code;
                    promoCodeResponse.ErrorMessage = ErrorMessageConstants.SUCCESS;
                }
                else
                {
                    promoCodeResponse.ErrorCode = ErrorCode.Failed_Code;
                    promoCodeResponse.ErrorMessage = ErrorMessageConstants.FAILED;
                }
            }
            catch (ArgumentNullException argex)
            {
                promoCodeResponse.ErrorCode = ErrorCode.Failed_Code;
                promoCodeResponse.ErrorMessage = argex.ParamName.ToString();
            }
            catch (Exception ex)
            {
                promoCodeResponse.ErrorCode = ErrorCode.SystemError_Code;
                promoCodeResponse.ErrorMessage = ex.GetBaseException().ToString();
            }
            
            return promoCodeResponse;
        }

        public async Task<IEnumerable<PromoCode>> GetUnusedEVoucherAsync()
        {
            return (IEnumerable<PromoCode>)await _promoCodeRepository.GetUnusedEVoucher();
        }

        public async Task<IEnumerable<PromoCode>> GetUsedEVoucherAsync()
        {
            return (IEnumerable<PromoCode>)await _promoCodeRepository.GetUsedEVoucher();
        }

        public async Task<PromoCodeVerifyResponse> VerifyPromoCodeAsync(string promoCode)
        {
            PromoCodeVerifyResponse promoCodeResponse = new PromoCodeVerifyResponse();
            try
            {
                if (string.IsNullOrEmpty(promoCode))
                    throw new ArgumentNullException(ErrorMessageConstants.INVALID_PROMO_CODE);

                PromoCode promoCodes = await _promoCodeRepository.GetByPromoCode(promoCode);
                if (promoCodes != null)
                {
                    if(promoCodes.IsRedeemed)
                        throw new ArgumentNullException(ErrorMessageConstants.ALREADY_USED);

                    promoCodes.IsRedeemed = AppConsts.Redeemed;
                    promoCodes.IsUsed = AppConsts.Invalid;

                    await _promoCodeRepository.Update(promoCodes);

                    promoCodeResponse.ErrorCode = ErrorCode.Success_Code;
                    promoCodeResponse.ErrorMessage = ErrorMessageConstants.SUCCESS;
                }
                else
                {
                    promoCodeResponse.ErrorCode = ErrorCode.Failed_Code;
                    promoCodeResponse.ErrorMessage = ErrorMessageConstants.FAILED;
                }
            }
            catch (ArgumentNullException argex)
            {
                promoCodeResponse.ErrorCode = ErrorCode.Failed_Code;
                promoCodeResponse.ErrorMessage = argex.ParamName.ToString();
            }
            catch (Exception ex)
            {
                promoCodeResponse.ErrorCode = ErrorCode.SystemError_Code;
                promoCodeResponse.ErrorMessage = ex.GetBaseException().ToString();
            }

            return promoCodeResponse;
        }

        #endregion

    }
}
