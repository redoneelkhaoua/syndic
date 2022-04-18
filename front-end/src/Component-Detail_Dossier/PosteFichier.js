import React ,{ useState} from "react";
import ChangeForma from "./Modal/ChangeForma";
function PosteFichier({post,i,posts}) {
    const [isopen, setopen ] = useState(false);
    function saveChange(){
        setopen(true)
    }
    var date= null;
    if(i!=0){
        date =posts[i-1].creationDate
        }
     return (<>
        <div className="vote">
        <div>
          {date != post.creationDate ? (
            <div className="continer">
            <div>
              <div className="line1"></div>
              <p className="dateNote">{post.creationDate}</p>
              <div className="line2"></div>
            </div>
            </div>
            ): null}
        </div>
            <div className="posteChadow">
                <div className="fichier">
                    <img src={post._file} className="fichierImage" onClick={saveChange} />
                </div>
            </div>
        </div>
        
        {isopen ?<ChangeForma post={post} setopen={setopen}/>: null }
    </>);
}
export default PosteFichier;