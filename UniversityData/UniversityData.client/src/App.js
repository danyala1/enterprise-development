import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ListRectors from './components/ListRectors/ListRectors';
import CreateRector from './components/CreateRector/CreateRector';
import EditRector from './components/EditRector/EditRector';
import ViewRector from './components/ViewRector/ViewRector';

const App = () => (
  <Router>
    <Routes>
      <Route path="/" element={<ListRectors />} />
      <Route path="/rectors/create" element={<CreateRector />} />
      <Route path="/rectors/edit/:id" element={<EditRector />} />
      <Route path="/rectors/view/:id" element={<ViewRector />} />
    </Routes>
  </Router>
);

export default App;