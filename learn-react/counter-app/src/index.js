import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';
import Counter from './components/counter'

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Counter></Counter>
);
