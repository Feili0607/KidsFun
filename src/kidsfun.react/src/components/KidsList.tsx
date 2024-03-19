// components/KidsList.tsx

import React from 'react';
import { KidDto } from '../types';
import { Table, TableBody, TableCell, TableContainer, TableRow, Paper, Button, TableHead } from '@mui/material';

interface KidsListProps {
  kids: KidDto[];
  onEditKid: (kid: KidDto) => void; // Function to call when the "Edit" button is clicked
}

const KidsList: React.FC<KidsListProps> = ({ kids, onEditKid }) => {
  return (
    <TableContainer component={Paper}>
      <Table aria-label="kids table">
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell align="right">Birth Date</TableCell>
            <TableCell align="right">Gender</TableCell>
            <TableCell align="right">Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {kids.map((kid) => (
            <TableRow key={kid.id}>
              <TableCell component="th" scope="row">
                {kid.name}
              </TableCell>
              <TableCell align="right">{kid.birthDate}</TableCell>
              <TableCell align="right">{kid.gender}</TableCell>
              <TableCell align="right">
                <Button color="primary" onClick={() => onEditKid(kid)}>
                  Edit
                </Button>
                {/* Include Delete button if you're handling delete within KidsList */}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      {kids.length === 0 && <p style={{ padding: 16 }}>No kids found.</p>}
    </TableContainer>
  );
};

export default KidsList;
