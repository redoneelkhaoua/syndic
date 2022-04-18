import React, { useEffect, useState } from "react";
import Header from "./Header";
import SideBare from "./SideBar";
import Categorie from "./Categorie";
import CreePost from "./PosteCreator";
import Fichier from "./Fichier";
import Vote from "./Vote";
import Statut from "./Statut";
import PosteList from "./PosteList";
import getCase, {
  getCategories,
  getStatuts,
  getVote,
  getResults,
} from "../ApiDetailDossier/ApiPosts";
import "./index.css";

function App() {
  const [results, setresult] = useState([]);
  const [posts, setposts] = useState([]);
  const [choix, setChoix] = useState([]);
  const [cases, setcase] = useState([]);
  let test = [];
  let choixCopys = [];
  useEffect(
    () => {
      async function getdata() {
        const Case = await getCase();
        Case.notes.map((n) => {
          test.push(n);
        });
        Case.votes.map((v) => {
          test.push(v);
        });
        Case._files.map((f) => {
          test.push(f);
        });
        var str;
        
        for (var i = 0; i < test.length; i++) {
          for (var j = i; j < test.length; j++) {
            if (
              new Date(test[i].creationDate) > new Date(test[j].creationDate)
            ) {
              str = test[i];
              test[i] = test[j];
              test[j] = str;
            }
          }
        }
        test.map((test) => {
          var date = new Date(test.creationDate);
          let dateMDY = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
          test.creationDate=dateMDY
        })

        const Results = await getResults();
        setresult(Results);

        const Categories = await getCategories();
        setCategories(Categories);

        const Statuts = await getStatuts();
        setStatut(Statuts);

        const Votes = await getVote();
        Votes.map((vote) => {
          vote.choices.map((choi) => {
            choixCopys.push(choi);
          });
        });
        setcase(Case);
        setposts(test);
        setChoix(choixCopys);
      }
      getdata();
    },
    [setposts],
    [posts]
  );

  const [input, setInput] = useState("");

  /*for  Statut ----------------------------*/

  const [Statuts, setStatut] = useState([]);

  async function onChangeStatut(e) {
    const cases = await getCase();
    console.log(cases);
    Statuts.map((statut) => {
      if (statut.statusName == e.target.value) {
        fetch("http://localhost:5052/api/Case/" + cases.idCase, {
          method: "PUT",
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          },
          body: JSON.stringify({
            idCase: cases.idCase,
            title: cases.title,
            description: cases.description,
            creationDate: cases.creationDate,
            category: cases.category,
            status: statut.idStatus,
          }),
        }).then((response) => {
          console.log(response);
          if (response.status == 200) {
            console.log("success");
          }
        });
        console.log(statut.idStatus, statut.statusName);
      }
    });
  }

  /*for creer  Fichier ----------------------------*/


  const [changeFichier, setChangeFichier] = useState("");
  let id = cases.idCase
  let file =''
  
   function handleChangeFichier(e) {
    file=e.target.files[0]
    let reader = new FileReader();
    reader.onload=() => {
      if(reader.readyState ==2){
        setChangeFichier(reader.result);
      }
    }
    reader.readAsDataURL( file)
  }

  function handeCreateFichiert(e) {

        fetch("http://localhost:5052/api/file", {
          method: "POST",
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            "Access-Control-Allow-Origin": "*",
          },
          body: JSON.stringify({
            _file: changeFichier,
            type: "Fichier",
            idCase: id,
          }),
        }).then((response) => {
          console.log(response);
          if (response.status == 200) {
            console.log("success");
          }
          return response.json();
        }) .then((data) => {
          console.log(data);
          setInput("");
         let  date= new Date(data.creationDate)
          let dateMdy = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
          data.creationDate=dateMdy;
          setposts([...posts, data]);
        });
  }
  /* for Categorie ----------------------------*/
  const [Categories, setCategories] = useState([]);

  async function onChangeCategorie(e) {
    const cases = await getCase();
    let idCategorie = null;
    Categories.map((Categorie) => {
      if (Categorie.categoryName == e.target.value) {
        idCategorie = Categorie.idCategorie;
      }
    });
    console.log(idCategorie);
    fetch("http://localhost:5052/api/Case/" + cases.idCase, {
      method: "PUT",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        idCase: cases.idCase,
        title: cases.title,
        description: cases.description,
        creationDate: cases.creationDate,
        category: idCategorie,
        status: cases.status,
      }),
    }).then((response) => {
      console.log(response);
      if (response.status == 200) {
        console.log("success");
      }
    });
  }

  /* code for create vote ----------------------------*/

  const [currentChoix, setcurrentChoix] = useState({
    idChoice: null,
    choice: "",
  });
  
  const [nouveauChoix, setNouveauChoix] = useState([]);

  function changeCreerChoix(e) {
    setcurrentChoix({
      ...currentChoix,
      choice: e.target.value,
      idChoice: Math.floor(Math.random() * 10000),
    });
    console.log(currentChoix.choice);
  }
  function ClickCreerChoix() {
    setcurrentChoix({
      ...currentChoix,
      idChoice: Math.floor(Math.random() * 100000),
    });
    setNouveauChoix([...nouveauChoix, currentChoix]);
    console.log(nouveauChoix);
  }

  function handlSupprChoix(choix) {
    setNouveauChoix(
      nouveauChoix.filter((choi) => choi.idChoice != choix.idChoice)
    );
  }
  const [titreVote, setTitreVote] = useState("");
  function onChoncheTitre(e) {
    setTitreVote(e.target.value);
    console.log(titreVote);
  }
  let listchoix = [];
  async function handleCreerVote() {
    const cases = await getCase();
    choix.map((choice) => {
      listchoix.push(choice)
    })
    console.log(choix);
    console.log(listchoix);
    fetch("http://localhost:5052/api/Vote", {
      method: "POST",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        title: titreVote,
        type: "vote",
        idCase: cases.idCase,
        choices: nouveauChoix,
      }),
    }).then((response) => {
      console.log(response);
      if (response.status == 200) {
        console.log("success");
      }
      return response.json();
    }).then((data) => {
      console.log(data);
      let  date= new Date(data.creationDate)
      let dateMdy = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
      data.creationDate=dateMdy;
      setposts([...posts, data]);
      data.choices.map((choic)=>{
        listchoix.push(choic) 
        console.log(choic)
      })
      setChoix(listchoix)
    });
    setNouveauChoix([]);
  }

  /* code for create note ----------------------------*/
  const onInputChange = (e) => {
    setInput(e.target.value);
  };
  let choixList = [];
  async function onClickSubmit(e) {
   e.preventDefault();
    const cases = await getCase();

    fetch("http://localhost:5052/api/Note/", {
      method: "post",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        note: input,
        type: "note",
        idCase: cases.idCase,
      }),
    })
      .then((response) => {
        console.log(response);
        if (response.status == 200) {
          console.log("success");
        }
        return response.json();
      })
      .then((data) => {
        console.log(data);
        setInput("");
       let  date= new Date(data.creationDate)
        let dateMdy = `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
        data.creationDate=dateMdy;
        setposts([...posts, data]);
      });
  }

  return (
    <>
      <Header />

      <SideBare />
      <div id="content">
        <div id="flexx">
         
            <Categorie Categories={Categories} onchange={onChangeCategorie} />
            <Statut Statuts={Statuts} onChange={onChangeStatut} cases={cases} />
          

          <Fichier
            onChange={handleChangeFichier}
            onClick={handeCreateFichiert}
           
          />

          <Vote
            nouveauChoix={nouveauChoix}
            onChange={changeCreerChoix}
            onClick={ClickCreerChoix}
            onSupprime={handlSupprChoix}
            onCreer={handleCreerVote}
            onChoncheTitre={onChoncheTitre}
            posts={posts}
          />
        </div>

        <div className="postessimo">
          <PosteList
            posts={posts}
            setposts={setposts}
            choix={choix}
            setChoix={setChoix}
            results={results}
            setresult={setresult}
          />
        </div>
        <CreePost
          input={input}
          setInput={setInput}
          posts={posts}
          setposts={setposts}
          onInputChange={onInputChange}
          onClickSubmit={onClickSubmit}
        />
      </div>
    </>
  );
}

export default App;
