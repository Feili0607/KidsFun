// components/KidsList.tsx

import React, { useState } from 'react';
import { KidDto } from '../types';
import { Table, TableBody, TableCell, TableContainer, TableRow, Paper, Checkbox, Button, TableHead } from '@mui/material';

interface KidsListProps {
  kids: KidDto[];
  onEditKid: (kid: KidDto) => void; // Function to call when "Edit" button is clicked
  onDeleteSelected: (selectedIds: number[]) => void; // Function to call for deleting selected kids
}

const KidsList: React.FC<KidsListProps> = ({ kids, onEditKid, onDeleteSelected }) => {
  const [selectedKids, setSelectedKids] = useState<number[]>([]);

  const handleSelect = (id: number) => {
    const selectedIndex = selectedKids.indexOf(id);
    let newSelected: number[] = [];

    if (selectedIndex === -1) {
      newSelected = newSelected.concat(selectedKids, id);
    } else {
      newSelected = selectedKids.filter(selectedId => selectedId !== id);
    }

    setSelectedKids(newSelected);
  };

  const handleDeleteSelected = () => {
    onDeleteSelected(selectedKids);
    setSelectedKids([]); // Reset selection after deletion
  };

  const isSelected = (id: number) => selectedKids.includes(id);

  return (
    <>
      <TableContainer component={Paper}>
        <Table aria-label="kids table">
          <TableHead>
            <TableRow>
              <TableCell padding="checkbox">Select</TableCell>
              <TableCell>Name</TableCell>
              <TableCell align="right">Birth Date</TableCell>
              <TableCell align="right">Gender</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {kids.map((kid) => (
              <TableRow key={kid.id} selected={isSelected(kid.id)}>
                <TableCell padding="checkbox">
                  <Checkbox
                    color="primary"
                    checked={isSelected(kid.id)}
                    onChange={() => handleSelect(kid.id)}
                  />
                </TableCell>
                <TableCell component="th" scope="row">{kid.name}</TableCell>
                <TableCell align="right">{kid.birthDate}</TableCell>
                <TableCell align="right">{kid.gender}</TableCell>
                <TableCell align="right">
                  <Button color="primary" onClick={() => onEditKid(kid)}>
                    Edit
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Button
        style={{ marginTop: '20px' }}
        variant="contained"
        color="secondary"
        onClick={handleDeleteSelected}
        disabled={selectedKids.length === 0}
      >
        Delete Selected
      </Button>
    </>
  );
};

export default KidsList;
