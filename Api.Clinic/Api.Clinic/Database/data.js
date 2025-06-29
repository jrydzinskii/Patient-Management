import { collection, doc, setDoc } from "firebase/firestore"; 

const physiciansRef = collection(db, "Physicians");
const Physicians =[ 
{
   Physid:1, Name: "Santa Claus", GradDate:12/10/2003, 
    Special: Cardiology, License: 860000,
 },
 {
    Physid:2, Name: "MIss Claus", GradDate:10/10/2013, 
     Special: Optometrist, License: 9238290,
  },
  {
    Physid:3, Name: "Jordan Claus", GradDate:10/10/2017, 
     Special: Radiologist, License: 879203,
  }
];