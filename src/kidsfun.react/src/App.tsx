import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import KidsPage from './pages/KidsPage';
import AssignmentsPage from './pages/AssignmentsPages';

const App = () => (
  <Router>
    <Routes>
      <Route path="/kids" element={<KidsPage/>}/>
      <Route path="/assignment" element={<AssignmentsPage/>}/>
      <Route path="*" element={<KidsPage/>}/>
    </Routes>
</Router>
);

export default App;