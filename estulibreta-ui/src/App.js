import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';

function App() {

  const [testState, setTestState] = useState(1);

  return (
    <div className="App">
      {testState}
    </div>
  );
}

export default App;
