import {useState, useEffect} from 'react'
import './App.css'

function App() {
  const url = "http://localhost:5000";
  const [data, setData] = useState({
    method: "",
    function: ""
  });

  useEffect(()=>{
      fetch(url)
      .then((res) => { return res.json()})
      .then((data) => { data = setData(data)
    })}
  , []);
  console.log(data)

  return (
    <>
      <div>
        <p>
          {data.method} {data.function}
        </p>
      </div>
    </>
  )
}

export default App
