import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import api from '../../api/api';
import { Typography, Card, CardContent, CircularProgress } from '@mui/material';
import './ViewRector.scss';

const ViewRector = () => {
  const { id } = useParams();
  const [rector, setRector] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchRector = async () => {
      try {
        const response = await api.get(`/Rector/${id}`);
        setRector(response.data);
        setLoading(false);
      } catch (error) {
        setLoading(false);
        console.error('Failed to fetch rector data.');
      }
    };

    fetchRector();
  }, [id]);

  if (loading) {
    return (
      <div className="view-rector">
        <CircularProgress />
      </div>
    );
  }

  if (!rector) {
    return (
      <div className="view-rector">
        <Typography variant="h5">Rector not found.</Typography>
      </div>
    );
  }

  return (
    <div className="view-rector">
      <Card className="rector-card">
        <CardContent>
          <Typography variant="h5">{rector.fullName}</Typography>
          <Typography variant="body1"><strong>Degree:</strong> {rector.degree}</Typography>
          <Typography variant="body1"><strong>Title:</strong> {rector.title}</Typography>
          <Typography variant="body1"><strong>Position:</strong> {rector.position}</Typography>
        </CardContent>
      </Card>
    </div>
  );
};

export default ViewRector;
