using EVoucher.Cms.Entities.Const;
using EVoucher.Cms.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVoucher.Cms.Service.Manager
{
    public class ValidationManager : IValidationManager
    {
        public void ValidCreateVoucherRequest(EvoucherRequest evoucherRequest)
        {
            if (evoucherRequest == null)
                throw new ArgumentNullException(ErrorMessageConstants.REQUEST_OBJECT_NULL);

            if (evoucherRequest.Title == null) 
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_TITLE);

            if (evoucherRequest.Description == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_DESCRIPTION);

            if (evoucherRequest.ExpiryDate == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_EXPIRY_DATE);

            if (evoucherRequest.Amount <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_AMOUNT);

            if (evoucherRequest.PaymentMethodId <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_PAYMENT_ID);

            if (evoucherRequest.PaymentMethodDiscountId <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_PAYMENT_DISCOUNT_ID);

            if (evoucherRequest.Quantity <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_QUANTITY);

            if (evoucherRequest.BuyType == null)
                throw new ArgumentNullException(ErrorMessageConstants.REQUEST_BUYTYPE_OBJECT_NULL);

            if (evoucherRequest.BuyType.Name == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_NAME);

            if (evoucherRequest.BuyType.PhoneNumber == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_PHONENUMBER);
        }

        public void ValidEditVoucherRequest(EvoucherRequest evoucherRequest)
        {
            if (evoucherRequest == null)
                throw new ArgumentNullException(ErrorMessageConstants.REQUEST_OBJECT_NULL);

            if (string.IsNullOrEmpty(evoucherRequest.Id.ToString()))
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_EVOUCHER_ID);

            if (evoucherRequest.Title == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_TITLE);

            if (evoucherRequest.Description == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_DESCRIPTION);

            if (evoucherRequest.ExpiryDate == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_EXPIRY_DATE);

            if (evoucherRequest.Amount <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_AMOUNT);

            if (evoucherRequest.PaymentMethodId <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_PAYMENT_ID);

            if (evoucherRequest.PaymentMethodDiscountId <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_PAYMENT_DISCOUNT_ID);

            if (evoucherRequest.Quantity <= 0)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_QUANTITY);

            if (evoucherRequest.BuyType == null)
                throw new ArgumentNullException(ErrorMessageConstants.REQUEST_BUYTYPE_OBJECT_NULL);

            if (evoucherRequest.BuyType.Name == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_NAME);

            if (evoucherRequest.BuyType.PhoneNumber == null)
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_PHONENUMBER);
        }

        public void ValidUpdateStatusRequest(long eVoucherId, bool isActive)
        {
            if (string.IsNullOrEmpty(eVoucherId.ToString()))
                throw new ArgumentNullException(ErrorMessageConstants.INVALID_EVOUCHER_ID);
        }
    }
}
