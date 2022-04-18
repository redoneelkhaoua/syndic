import React from "react";
import PosteNote from "./PosteNote";
import PosteVote from "./PosteVote";
import PosteFichier from "./PosteFichier";

function PosteList({ posts , choix , results ,setresult}) {
   
  return (
    <>
      {posts.map(function (post ,i ,posts) {
        if (post.type === "note") {
          return <PosteNote post={post} i={i} posts={posts}/>;
        } else if (post.type === "vote") {
          return <PosteVote post={post} choix={choix} results={results}  i={i} posts={posts} setresult={setresult}/>;
        } else if (post.type === "Fichier") {
          return <PosteFichier post={post}  i={i} posts={posts}/>;
        }
 
        return null; 
      }

      )}
    </>
  );
}

export default PosteList;
