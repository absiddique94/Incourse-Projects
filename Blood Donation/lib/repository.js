function Repo() {
    this.data = [
        { id:1, name: 'Nigar Afroz', age: '26', bgroup: 'A+', address:'Mirpur-1,Dhaka', picture: 'nigar.jpg' },
        { id:2, name: 'Maeesha Rahman', age: '28', bgroup: 'A-', address:'Green Road, Dhaka', picture: 'maeesha.jpg' },
        { id:3, name: 'Tafeef Rahman', age: '25', bgroup: 'B+', address:'Mohammadpur, Dhaka', picture: 'tafeef.jpg' },
		{ id:4, name: 'Labeeb Saifan', age: '22', bgroup: 'B-', address:'Farmgate, Dhaka', picture: 'labeeb.jpg' },
		{ id:5, name: 'Mamun Rashid', age: '30', bgroup: 'O+', address:'Nakhalpara, Dhaka', picture: 'mamun.jpg' },
		{ id:6, name: 'Sadia Sultana', age: '19', bgroup: 'AB+', address:'Mohakhali, Dhaka', picture: 'sadia.jpg' },
		{ id:7, name: 'Rasel Mia', age: '27', bgroup: 'AB-', address:'Gulshan, Dhaka', picture: 'rasel.jpg' },
		{ id:8, name: 'Anisul Haque', age: '29', bgroup: 'O-', address:'Banani, Dhaka', picture: 'anisul.jpg' }

		
    ];
    this.insert = (blood) => {
        this.data.push(blood);
    }
	this.get = (id)=>{
       var blood = this.data.filter(p=> p.id == id);
       if(blood && blood.length) return blood[0];
       else return null;
    }
    this.update = (id, blood) => {
        var bloods= this.data.filter(b=> b.id == id);
        if(bloods || bloods.length)
        {
          bloods[0].name=blood.name;
          bloods[0].age = blood.age;
          bloods[0].bgroup = blood.bgroup;
          bloods[0].address = blood.address;
          console.log(this.bloods);
        }
    };
}
module.exports.repo = new Repo();