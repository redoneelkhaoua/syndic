import React from "react";
import ChoixVote from "./ChoixVote";

function PosteVote({ post, choix ,results,i,posts,setresult} ) {
  var date= null;
    if(i!=0){
        date =posts[i-1].creationDate
        }
      console.log(post.creationDate)
  return (
    <>
      <div>
      {date != post.creationDate ? (
            <div>
              <div className="line1"></div>
              <p className="dateNote">{post.creationDate}</p>
              <div className="line2"></div>
            </div>
            ): null}
        </div>
        <div className="voteshadow">
          <p className="titleVote1">{post.title}</p>
          {choix.map(function (choix) {
            if (choix.idVote == post.idVote) {
               return <ChoixVote choix={choix} results={results} post={post} setresult={setresult}/>
            }
            return null;
          })}
        </div>
    </>
  );
}
export default PosteVote;
