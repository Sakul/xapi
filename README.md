# PromptPay-Redemgo

# สร้าง QR code ด้วย Credit transfer (tag 29)
```
POST https://localhost:52866/PromptPay/transfer
Content-Type: application/json

{
  "isQrReusable": true,
  "creditTransfer": {
    "mobileNumber": "0914185401"
  }
}
```

Response
```json
{
  "qrCode": "00020101021129370016A0000006770101110113006691418540153037645802TH6304FF86",
  "errorMessage": null
}
```
Body เพิ่มเติม
```json
{
  "mobileNumber": "เบอร์มือถือ",
  "nationalIdOrTaxId": "รหัสประจำตัวประชาชน หรือ เลขประจำตัวผู้เสียภาษีอากร",
  "eWalletId": "e-wallet-id",
  "bankAccount": "เลขบัญชีธนาคาร",
  "ota": "???",
  "customerPresentedQR": true // true=ลูกค้าสร้าง QR ให้ร้านค้าสแกน, false=ร้านค้าสร้าง QR ให้ลูกค้าสแกน
}
```

# สร้าง QR code ด้วย Bill payment (tag 30)
```
POST https://localhost:52866/PromptPay/bill
Content-Type: application/json

{
  "isQrReusable": true,
  "billPayment": {
    "billerId": "01150105523009350",
    "suffix": "08",
    "reference1": "ref1",
    "reference2": "ref2",
    "crossBorderMerchantQR": false
  }
}
```

Response
```json
{
  "qrCode": "00020101021130590016A000000677010112011901150105523009350080204ref10304ref253037645802TH63044DAE",
  "errorMessage": null
}
```

# ถอดรหัส QR code ออกเป็นส่วนๆ
```
GET https://localhost:52866/PromptPay/00020101021229370016A000000677010111011300669141854015303764540550.005802TH630401F8
```

Response
```json
{
  "Reusable": false,
  "Currency": "THB",
  "CreditTransfer": {
    "AID": "A000000677010111",
    "MobileNumber": "66914185401",
    "NationalIdOrTaxId": null,
    "EWalletId": null,
    "BankAccount": null,
    "OTA": null,
    "CustomerPresentedQR": false
  },
  "BillPayment": null,
  "Segments": [
    {
      "RawValue": "000201",
      "Id": "00",
      "Length": "02",
      "Value": "01",
      "IdByConvention": 0
    },
    {
      "RawValue": "010212",
      "Id": "01",
      "Length": "02",
      "Value": "12",
      "IdByConvention": 1
    },
    {
      "RawValue": "29370016A00000067701011101130066914185401",
      "Id": "29",
      "Length": "37",
      "Value": "0016A00000067701011101130066914185401",
      "IdByConvention": 2
    },
    {
      "RawValue": "5303764",
      "Id": "53",
      "Length": "03",
      "Value": "764",
      "IdByConvention": 53
    },
    {
      "RawValue": "540550.00",
      "Id": "54",
      "Length": "05",
      "Value": "50.00",
      "IdByConvention": 54
    },
    {
      "RawValue": "5802TH",
      "Id": "58",
      "Length": "02",
      "Value": "TH",
      "IdByConvention": 58
    },
    {
      "RawValue": "630401F8",
      "Id": "63",
      "Length": "04",
      "Value": "01F8",
      "IdByConvention": 63
    }
  ],
  "PayloadFormatIndicator": "01",
  "PointOfInitiationMethod": "12",
  "MerchantAccountInformation": "0016A00000067701011101130066914185401",
  "MerchantCategoryCode": null,
  "TransactionCurrency": "764",
  "TransactionAmount": "50.00",
  "TipOrConvenienceIndicator": null,
  "ValueOfConvenienceFeeFixed": null,
  "ValueOfConvenienceFeePercentage": null,
  "CountryCode": "TH",
  "MerchantName": null,
  "MerchantCity": null,
  "PostalCode": null,
  "AdditionalData": null,
  "CRC": "01F8",
  "MerchantInformationLanguageTemplate": null,
  "RFU": null
}
```
