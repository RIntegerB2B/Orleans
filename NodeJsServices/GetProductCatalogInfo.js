const express = require('express')
const app = express()

app.get('/', function (req, res) {
  res.json({ModuleId:30, ModuleDescription: "Service",Options:[{OptionId: 1, OptionName: "2 year basic service"},{OptionId: 2, OptionName: "15 year basic service"}]});
});

app.listen(3023, () => console.log('Example app listening on port 3022! Product Info'))