const express = require('express')
const app = express()



/*app.get('/', function (req, res) {
	setTimeout(function(){
		res.send('{"id":1, "ProductPrice" : "30.00"}');
	}, 3000);
  
}); */

app.get('/', function (req, res) {
  res.json({RetailPrice:1111.11, OfferPrice: 2222.22, ContractPrice:3333.33});
});

app.listen(3021, () => console.log('Example app listening on port 3000!'))