import React, { useCallback, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../../api/api';
import { Button, Table, TableBody, TableCell, TableHead, TableRow, Snackbar, Alert } from '@mui/material';
import './ListRectors.scss';

const ListRectors = () => {
  const [rectors, setRectors] = useState([]);
  const [notification, setNotification] = useState({ open: false, message: '', severity: '' });

  const fetchRectors = useCallback(async () => {
    try {
      const response = await api.get('/Rector');
      setRectors(response.data);
    } catch (error) {
      showNotification('Failed to fetch rectors.', 'error');
    }
  }, []);

  useEffect(() => {
    fetchRectors();
  }, [fetchRectors]);

  const deleteRector = async (id) => {
    try {
      await api.delete(`/Rector/${id}`);
      fetchRectors();
      showNotification('Rector deleted successfully.', 'success');
    } catch (error) {
      showNotification('Failed to delete rector.', 'error');
    }
  };

  const showNotification = (message, severity) => {
    setNotification({ open: true, message, severity });
  };

  const closeNotification = () => {
    setNotification({ ...notification, open: false });
  };

  return (
    <div className="list-rectors">
      <h1>Rectors</h1>
      <Button component={Link} to="/rectors/create" variant="contained" color="primary">
        Add Rector
      </Button>
      <Table className="rectors-table">
        <TableHead>
          <TableRow>
            <TableCell>Full Name</TableCell>
            <TableCell>Degree</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rectors.map((rector) => (
            <TableRow key={rector.universityId}>
              <TableCell>{rector.fullName}</TableCell>
              <TableCell>{rector.degree}</TableCell>
              <TableCell>
                <Button component={Link} to={`/rectors/view/${rector.universityId}`} color="info">View</Button>
                <Button component={Link} to={`/rectors/edit/${rector.universityId}`} color="warning">Edit</Button>
                <Button onClick={() => deleteRector(rector.universityId)} color="error">Delete</Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <Snackbar
        open={notification.open}
        autoHideDuration={3000}
        onClose={closeNotification}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
      >
        <Alert onClose={closeNotification} severity={notification.severity} variant="filled">
          {notification.message}
        </Alert>
      </Snackbar>
    </div>
  );
};

export default ListRectors;
