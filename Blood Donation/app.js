const fs = require('fs-extra');
const express = require('express');
const formidable = require('formidable');
const app = express();
const repo = require('./lib/repository').repo;

app.set('view engine', "raz");

app.use(express.static(__dirname + '/www'));

app.get('/list', (req, res) => {
    res.json(repo.data);
});
app.post("/create", (req, res) => {
    var form = new formidable.IncomingForm();
    var blood = {};
	blood.id = repo.data.length+1;
    form.parse(req, (err, flds, files) => {
        console.log(flds);
        blood.name = flds.name;
        blood.age = flds.age;
        blood.bgroup = flds.bgroup;
        blood.address = flds.address;
        blood.picture = 'uploads/' + files.picture.name;
        repo.insert(blood);
        var src = files.picture.path;
        var dest = __dirname + "\\www\\Images\\uploads\\" + files.picture.name
        
        fs.copy(src, dest, function (err) {
            if (err) {
                console.error(err);
            } else {
                console.log("success!")
            }
        });
        res.redirect("/donors.html");
    });
});

app.get('/edit/:id', (req, res)=>{
  var blood =repo.get(req.params.id);
  res.render('edit', {id:blood.id, 
    name:blood.name, age:blood.age, 
    bgroup: blood.bgroup, address: blood.address, picture: blood.picture});
});

app.post('/edit/:id', (req, res)=>{
  var id = req.params.id;
  var form = new formidable.IncomingForm();
  form.parse(req, (err, flds)=>{
    repo.update(id, {name:flds.name, age:flds.age, 
        bgroup:flds.bgroup, address:flds.address});
  });
  res.redirect("/donors.html");
  
});

app.listen(8181);
console.log("Server running at port 8181..");
