// components/EditKidDialog.tsx

import React, { useEffect, useState } from 'react';
import { Dialog, DialogActions, DialogContent, DialogTitle, Button, TextField } from '@mui/material';
import { KidDto } from '../types';

interface EditKidDialogProps {
  kid: KidDto | null; // null when adding, filled object when editing
  isOpen: boolean;
  onClose: () => void;
  onSave: (kid: KidDto) => void; // Use onSave to handle both add and edit
}

const EditKidDialog: React.FC<EditKidDialogProps> = ({ kid, isOpen, onClose, onSave }) => {
  const [editedKid, setEditedKid] = useState<KidDto>({ id: 0, name: '', birthDate: '', gender: '' });

  useEffect(() => {
    // Load the kid to edit into state, or reset state if adding a new kid
    if (kid) {
      setEditedKid(kid);
    } else {
      setEditedKid({ id: 0, name: '', birthDate: '', gender: '' });
    }
  }, [kid, isOpen]); // Re-run this effect if the kid prop or isOpen changes

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setEditedKid({ ...editedKid, [name]: value });
  };

  const handleSave = () => {
    onSave(editedKid);
    onClose();
  };

  return (
    <Dialog open={isOpen} onClose={onClose}>
      <DialogTitle>{kid ? 'Edit Kid' : 'Add Kid'}</DialogTitle>
      <DialogContent>
        <TextField
          autoFocus
          margin="dense"
          name="name"
          label="Name"
          type="text"
          fullWidth
          variant="standard"
          value={editedKid.name}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          name="birthDate"
          label="Birth Date"
          type="date"
          fullWidth
          variant="standard"
          InputLabelProps={{
            shrink: true,
          }}
          value={editedKid.birthDate}
          onChange={handleChange}
        />
        <TextField
          margin="dense"
          name="gender"
          label="Gender"
          type="text"
          fullWidth
          variant="standard"
          value={editedKid.gender}
          onChange={handleChange}
        />
        {/* Add more fields as necessary */}
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose}>Cancel</Button>
        <Button onClick={handleSave}>Save</Button>
      </DialogActions>
    </Dialog>
  );
};

export default EditKidDialog;
