const express = require('express')
const app = express()

app.get('/', (req, res) => res.json({ValidationResponseMessage:"InValid Selection", Valid : false}))

app.listen(3020, () => console.log('Example app listening on port 3020!'))