using EVoucher.Cms.Entities.Const;
using EVoucher.Cms.Entities.Dtos;
using EVoucher.Cms.Entities.Entities;
using EVoucher.Cms.Repository.Repositories;
using EVoucher.Cms.Service.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVoucher.Cms.Service
{
    public class VoucherService : IVoucherService
    {
        #region Private variable
        private readonly IVoucherRepository _voucherRepository;
        private readonly IValidationManager _validationManager;
        private readonly IBuyTypeRepository _buyTypeRepository;
        #endregion

        #region Constructor
        public VoucherService(IVoucherRepository voucherRepository,
                              IBuyTypeRepository buyTypeRepository,
                              IValidationManager validationManager)
        {
            _voucherRepository = voucherRepository;
            _buyTypeRepository = buyTypeRepository;
            _validationManager = validationManager;
        }
        #endregion

        #region Public Method
        public async Task<EvoucherResponse> CreateAsync(EvoucherRequest evoucherRequest)
        {
            EvoucherResponse evoucherResponse = new EvoucherResponse();
            try
            {
                _validationManager.ValidCreateVoucherRequest(evoucherRequest);

                Voucher voucher = new Voucher();
                voucher = MapToCreateVoucherObject(evoucherRequest);
                await _voucherRepository.Add(voucher);

                long insertedId = await _voucherRepository.GetLastInsertedID();
                BuyType buyType = new BuyType
                {
                    CouponTypeId = evoucherRequest.CouponTypeId,
                    EvoucherId = insertedId,
                    Name = evoucherRequest.BuyType.Name,
                    PhoneNumber = evoucherRequest.BuyType.PhoneNumber,
                    MaxLimitByGift = evoucherRequest.BuyType.MaxLimitByGift,
                    MaxLimitBySelf = evoucherRequest.BuyType.MaxLimitBySelf,
                };
                await _buyTypeRepository.Add(buyType);


                evoucherResponse.ErrorCode = ErrorCode.Success_Code;
                evoucherResponse.ErrorMessage = ErrorMessageConstants.SUCCESS;
            }
            catch (ArgumentNullException argex)
            {
                evoucherResponse.ErrorCode = ErrorCode.Failed_Code;
                evoucherResponse.ErrorMessage = argex.ParamName.ToString();
            }
            catch (Exception ex)
            {
                evoucherResponse.ErrorCode = ErrorCode.SystemError_Code;
                evoucherResponse.ErrorMessage = ex.GetBaseException().ToString();
            }

            return evoucherResponse;
        }

        public async Task<EvoucherResponse> EditAsync(EvoucherRequest evoucherRequest)
        {
            EvoucherResponse evoucherResponse = new EvoucherResponse();
            try
            {
                _validationManager.ValidEditVoucherRequest(evoucherRequest);

                Voucher voucher = new Voucher();
                voucher = MapToEditVoucherObject(evoucherRequest);
                await _voucherRepository.Update(voucher);

                BuyType buyType = new BuyType();
                buyType = await _buyTypeRepository.GetByeVoucherId(voucher.Id);
                if (buyType != null)
                {
                    buyType.CouponTypeId = evoucherRequest.CouponTypeId;
                    buyType.EvoucherId = voucher.Id;
                    buyType.Name = evoucherRequest.BuyType.Name;
                    buyType.PhoneNumber = evoucherRequest.BuyType.PhoneNumber;
                    buyType.MaxLimitByGift = evoucherRequest.BuyType.MaxLimitByGift;
                    buyType.MaxLimitBySelf = evoucherRequest.BuyType.MaxLimitBySelf;
                
                    await _buyTypeRepository.Update(buyType);
                }

                evoucherResponse.ErrorCode = ErrorCode.Success_Code;
                evoucherResponse.ErrorMessage = ErrorMessageConstants.SUCCESS;
            }
            catch (ArgumentNullException argex)
            {
                evoucherResponse.ErrorCode = ErrorCode.Failed_Code;
                evoucherResponse.ErrorMessage = argex.ParamName.ToString();
            }
            catch (Exception ex)
            {
                evoucherResponse.ErrorCode = ErrorCode.SystemError_Code;
                evoucherResponse.ErrorMessage = ex.GetBaseException().ToString();
            }

            return evoucherResponse;
        }

        public async Task<EvoucherResponse> UpdateStatusAsync(long eVoucherId, bool isActive)
        {
            EvoucherResponse evoucherResponse = new EvoucherResponse();
            try
            {
                _validationManager.ValidUpdateStatusRequest(eVoucherId, isActive);

                Voucher voucher = await _voucherRepository.Get(eVoucherId);
                if (voucher != null)
                {
                    voucher.Status = isActive;
                    await _voucherRepository.Update(voucher);

                    evoucherResponse.ErrorCode = ErrorCode.Success_Code;
                    evoucherResponse.ErrorMessage = ErrorMessageConstants.SUCCESS;
                }
                else
                {
                    evoucherResponse.ErrorCode = ErrorCode.Failed_Code;
                    evoucherResponse.ErrorMessage = ErrorMessageConstants.FAILED;
                }                
            }
            catch (ArgumentNullException argex)
            {
                evoucherResponse.ErrorCode = ErrorCode.Failed_Code;
                evoucherResponse.ErrorMessage = argex.ParamName.ToString();
            }
            catch (Exception ex)
            {
                evoucherResponse.ErrorCode = ErrorCode.SystemError_Code;
                evoucherResponse.ErrorMessage = ex.GetBaseException().ToString();
            }

            return evoucherResponse;
        }
        #endregion

        #region Private Method
        private Voucher MapToCreateVoucherObject(EvoucherRequest evoucherRequest)
        {
            Voucher voucher = new Voucher
            {
                Title = evoucherRequest.Title,
                Description = evoucherRequest.Description,
                Image = evoucherRequest.Image,
                ExpiryDate = evoucherRequest.ExpiryDate,
                PaymentMethodId = evoucherRequest.PaymentMethodId,
                PaymentMethodDiscountId = evoucherRequest.PaymentMethodDiscountId,
                Amount = evoucherRequest.Amount,
                Quantity = evoucherRequest.Quantity,
                Status = evoucherRequest.Status,
                Created_date = DateTime.Now
            };

            return voucher;

        }

        private Voucher MapToEditVoucherObject(EvoucherRequest evoucherRequest)
        {
            Voucher voucher = new Voucher
            {
                Id = evoucherRequest.Id,
                Title = evoucherRequest.Title,
                Description = evoucherRequest.Description,
                Image = evoucherRequest.Image,
                ExpiryDate = evoucherRequest.ExpiryDate,
                PaymentMethodId = evoucherRequest.PaymentMethodId,
                PaymentMethodDiscountId = evoucherRequest.PaymentMethodDiscountId,
                Amount = evoucherRequest.Amount,
                Quantity = evoucherRequest.Quantity,
                Status = evoucherRequest.Status,
                Created_date = DateTime.Now
            };

            return voucher;

        }
        #endregion
    }
}
