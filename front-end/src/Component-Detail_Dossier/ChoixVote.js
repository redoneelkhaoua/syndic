import React, { useState, useEffect } from "react";

function ChoixVote({ choix, results, post ,setresult }) {
  let conteur = 0;
  let checked = 0;
  let disabledVote=0;
  let ResultaTotal =0;
  let PercentageChoix =0;
  function handlechange(e) {
    fetch("http://localhost:5052/api/Results", {
      method: "POST",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
        "Access-Control-Allow-Origin": "*",
      },
      body: JSON.stringify({
        idVote: post.idVote,
        idChoice: choix.idChoice,
        idParticipant: 1,
      }),
    }).then((response) => {
      console.log(response);
      if (response.status == 200) {
        console.log("success");
      }
      return response.json();
    }) .then((data) => {
      setresult([...results, data]);
    });
  }
  results.map((result) => {
    if (result.idChoice === choix.idChoice) {
      checked = 1;
    }
    if (result.idVote === post.idVote) {
      disabledVote = 1;
    }
    if(result.idVote == post.idVote) {
      ResultaTotal ++;
    }
    if (result.idChoice == choix.idChoice) {
      conteur++;
    }
  });
  if (conteur >0) {
    PercentageChoix=(conteur/ResultaTotal)*100
    PercentageChoix =PercentageChoix.toPrecision(2);
  }
  
  return (
    <div className="scroll">

      <div className="choix">
        <input
          type="radio"
          name={`radio ${choix.idVote}`}
          className="check"
          onChange={handlechange}
          defaultChecked={checked == true ? true : false}
          disabled={disabledVote == true ? true : false}
          readOnly
        />
       
        <input type="text" className="value" 
         value={choix.choice} readOnly />
        <div className="widthPour">
           <div className="pourcentage" style={{width: `${PercentageChoix}%`}}></div>
        </div>

      </div>
      <p className="resulta1">{PercentageChoix+"%"}</p>
    </div>
  );
}

export default ChoixVote;
