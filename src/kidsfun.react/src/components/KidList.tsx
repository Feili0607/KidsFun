// src/components/KidList.tsx
import React, { useEffect, useState } from 'react';
import { fetchKids } from '../api/kidsApi';
import { KidDto } from '../types';

const KidList = () => {
  const [kids, setKids] = useState<KidDto[]>([]);

  useEffect(() => {
    const getKids = async () => {
      try {
        const response = await fetchKids();
        setKids(response.data); // Assuming the data is directly the array of kids
      } catch (error) {
        console.error("Failed to fetch kids:", error);
        // Handle errors or set some error state here if needed
      }
    };

    getKids();
  }, []);

  return (
    <div>
      <h2>Kids List</h2>
      {kids.length > 0 ? (
        <ul>
          {kids.map((kid) => (
            <li key={kid.id}>
               {kid.name} - Birth Date: {kid.birthDate}, Gender: {kid.gender}
              {/* Add more details you want to display */}
            </li>
          ))}
        </ul>
      ) : (
        <p>No kids found.</p>
      )}
    </div>
  );
};

export default KidList;
