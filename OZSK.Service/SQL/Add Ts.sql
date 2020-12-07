IF COL_LENGTH('Auto','Ts')IS NULL
BEGIN
ALTER TABLE Auto ADD Ts TimeStamp not NULL 
END

IF COL_LENGTH('Carrier','Ts')IS NULL
BEGIN
ALTER TABLE Carrier ADD Ts TimeStamp not NULL 
END

IF COL_LENGTH('Cipherlist','Ts')IS NULL
BEGIN
ALTER TABLE Cipherlist ADD Ts TimeStamp not NULL 
END

IF COL_LENGTH('Consignee','Ts')IS NULL
BEGIN
ALTER TABLE Consignee ADD Ts TimeStamp not NULL 
END

IF COL_LENGTH('Driver','Ts')IS NULL
BEGIN
ALTER TABLE Driver ADD Ts TimeStamp not NULL 
END

IF COL_LENGTH('ShippingName','Ts')IS NULL
BEGIN
ALTER TABLE ShippingName ADD Ts TimeStamp not NULL 
END
