const express = require('express')
const app = express()

app.get('/', function (req, res) {
  res.json({ProductItemId:"DSPEFX2", ItemType: "Config"});
});

app.listen(3022, () => console.log('Example app listening on port 3022! Product Info'))