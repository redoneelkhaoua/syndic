export default function getCase() {
   var params = new URLSearchParams(window.location.search),
    id = params.get("id");
    console.log(id) 
 return (
    fetch('http://localhost:5052/api/Case/'+id)
    .then((response) => response.json()
    )
   )
  };

export function getCategories() {
 return (
    fetch('http://localhost:5052/api/Case/Category')
    .then((response) => response.json()
    )
   )
  };

 export function getStatuts() {
   return (
      fetch('http://localhost:5052/api/Case/Status')
      .then((response) => response.json()
      )
     )
    };

 export function getVote() {
   return (
      fetch('http://localhost:5052/api/Vote')
      .then((response) => response.json()
      )
     )
    };
    
    export function getResults() {
      return (
         fetch('http://localhost:5052/api/Results')
         .then((response) => response.json()
         )
        )
       };