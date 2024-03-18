// src/pages/KidsPage.tsx
import React from 'react';
import KidForm from '../components/KidForm';
import KidList from '../components/KidList';

const KidsPage = () => {
  return (
    <div>
      <h1>Manage Kids</h1>
      <KidForm />
      <KidList />
    </div>
  );
};

export default KidsPage;