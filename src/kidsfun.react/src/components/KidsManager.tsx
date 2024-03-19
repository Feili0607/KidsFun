// components/KidsManager.tsx

import React, { useState, useEffect } from 'react';
import { Grid, Button, Paper } from '@mui/material';
import KidsList from './KidsList';
import EditKidDialog from './EditKidDialog';
import { fetchKids, deleteKids as deleteKidsApi, saveKid as saveKidApi } from '../api/kidsApi';
import { KidDto } from '../types';

const KidsManager: React.FC = () => {
  const [kids, setKids] = useState<KidDto[]>([]);
  const [editingKid, setEditingKid] = useState<KidDto | null>(null);
  const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

  useEffect(() => {
    loadKids();
  }, []);

  const loadKids = async () => {
    try {
      const response = await fetchKids();
      setKids(response.data);
    } catch (error) {
      console.error("Failed to fetch kids:", error);
    }
  };

  const handleOpenDialogForAdd = () => {
    setEditingKid(null); // Ensure dialog is in "add" mode
    setIsDialogOpen(true);
  };

  const handleOpenDialogForEdit = (kid: KidDto) => {
    setEditingKid(kid); // Preload dialog with kid's data for editing
    setIsDialogOpen(true);
  };

  const handleSaveKid = async (kid: KidDto) => {
    await saveKidApi(kid);
    loadKids();
    setIsDialogOpen(false);
  };

  const handleDeleteKid = async (kidIds: number[]) => {
    await deleteKidsApi(kidIds);
    loadKids();
  };

  return (
    <Paper style={{ padding: '20px', margin: '20px' }}>
      <Grid container direction="column" spacing={2}>
        <Grid item xs={12}>
          <KidsList kids={kids} onEditKid={handleOpenDialogForEdit} onDeleteSelected={handleDeleteKid} />
        </Grid>
        <Grid item container justifyContent="flex-end" spacing={2}>
          <Grid item>
            <Button variant="outlined" color="primary" onClick={handleOpenDialogForAdd}>
              Add New Kid
            </Button>
          </Grid>
          {/* Implement the Delete button here if necessary, depending on your UI/UX design */}
        </Grid>
      </Grid>
      <EditKidDialog
        kid={editingKid}
        isOpen={isDialogOpen}
        onClose={() => setIsDialogOpen(false)}
        onSave={handleSaveKid}
      />
    </Paper>
  );
};

export default KidsManager;
