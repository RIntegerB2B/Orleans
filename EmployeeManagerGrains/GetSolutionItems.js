const express = require('express')
const app = express()

app.get('/', (req, res) => res.send('{"id": 1, "Product Name" : "RX230"}'))

app.listen(3020, () => console.log('Example app listening on port 3000!'))