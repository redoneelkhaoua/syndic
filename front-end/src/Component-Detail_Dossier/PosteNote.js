import React from "react";
function PosteNote({ post ,i,posts}) {
    var date= null;
    if(i!=0){
        date =posts[i-1].creationDate
        }
  return (
    <>
      <div className="Postnote">
          {date != post.creationDate ? (
            <div className="continer">
            <div>
              <div className="line1"></div>
              <p className="dateNote">{post.creationDate}</p>
              <div className="line2"></div>
            </div>
            </div>
            ): null}

    
        <textarea className="areaBorder" value={post.note}></textarea>
      </div>
    </>
  );
}

export default PosteNote;
