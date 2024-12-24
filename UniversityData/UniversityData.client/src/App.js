import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import RectorList from './components/Rector/RectorList';
import RectorCreate from './components/Rector/RectorCreate';
import RectorEdit from './components/Rector/RectorEdit';
import RectorDelete from './components/Rector/RectorDelete';

import UniversityList from './components/University/UniversityList';
import UniversityCreate from './components/University/UniversityCreate';
import UniversityEdit from './components/University/UniversityEdit';
import UniversityDelete from './components/University/UniversityDelete';

import FacultyList from './components/Faculty/FacultyList';
import FacultyCreate from './components/Faculty/FacultyCreate';
import FacultyEdit from './components/Faculty/FacultyEdit';
import FacultyDelete from './components/Faculty/FacultyDelete';

import { Container, AppBar, Toolbar, Button, Typography } from '@mui/material';
import { Link } from 'react-router-dom';
import './App.css';
import RectorView from './components/Rector/RectorView';
import UniversityView from './components/University/UniversityView';
import FacultyView from './components/Faculty/FacultyView';

import AnalyticsTopDepartments from './components/University/Analytics/AnalyticsTopDepartments';
import AnalyticsSummaryByOwnershi from './components/University/Analytics/AnalyticsSummaryByOwnershi';

function App() {
  return (
    <Router>
      <AppBar position="sticky">
        <Toolbar>
          <Typography variant="h6" sx={{ flexGrow: 1 }}>
            University Management
          </Typography>
          <Button color="inherit" component={Link} to="/rectors">Rector</Button>
          <Button color="inherit" component={Link} to="/universities">University</Button>
          <Button color="inherit" component={Link} to="/faculties">Faculty</Button>
        </Toolbar>
      </AppBar>
      
      <Container sx={{ marginTop: 4 }}>
        <Routes>
          <Route path="/rectors" element={<RectorList />} />
          <Route path="/rectors/create" element={<RectorCreate />} />
          <Route path="/rectors/edit/:id" element={<RectorEdit />} />
          <Route path="/rectors/delete/:id" element={<RectorDelete />} />
          <Route path="/rectors/view/:id" element={<RectorView />} />
          <Route path="/universities" element={<UniversityList />} />
          <Route path="/universities/create" element={<UniversityCreate />} />
          <Route path="/universities/edit/:id" element={<UniversityEdit />} />
          <Route path="/universities/delete/:id" element={<UniversityDelete />} />
          <Route path="/universities/view/:id" element={<UniversityView />} />
          <Route path="/faculties" element={<FacultyList />} />
          <Route path="/faculties/create" element={<FacultyCreate />} />
          <Route path="/faculties/edit/:id" element={<FacultyEdit />} />
          <Route path="/faculties/delete/:id" element={<FacultyDelete />} />
          <Route path="/faculties/view/:id" element={<FacultyView />} />
          <Route path="/analytics/top-departments" element={<AnalyticsTopDepartments/>} />  
          <Route path="/analytics/summary-ownershi" element={<AnalyticsSummaryByOwnershi/>} />   
        </Routes>
      </Container>
    </Router>
  );
}

export default App;
