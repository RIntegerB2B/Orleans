start /min cmd /k "C:\My Folders\SellerECom\mongod.bat"
timeout 5
start /min cmd /k "C:\My Folders\SellerECom\mongo.bat"
start /min cmd /k "C:\My Folders\Orleans\NodeJsServices\ProdInfo.bat"
start /min cmd /k "C:\My Folders\Orleans\NodeJsServices\ProductCatalog.bat"
start /min cmd /k "C:\My Folders\Orleans\NodeJsServices\SolutionPrice.bat"
start /min cmd /k "C:\My Folders\Orleans\NodeJsServices\Validation.bat"