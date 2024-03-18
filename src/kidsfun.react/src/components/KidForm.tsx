// src/components/KidForm.tsx
import React, { useState } from 'react';
import { createKid } from '../api/kidsApi';
import { NewKidDto } from '../types';

const KidForm = () => {
  const [kid, setKid] = useState<NewKidDto>({ name: '', email: '', birthDate: '', gender: '' });
  const [error, setError] = useState('');

  const handleChange = (event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = event.target;
    setKid({ ...kid, [name]: value });
  };
  
  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    // Simple validation
    if (!kid.name || !kid.birthDate) {
      setError('Name and Birth Date are required.');
      return;
    }
    try {
      await createKid(kid);
      // Reset form (or handle success in another way, e.g., redirecting or showing a success message)
      setKid({ name: '', email: '', birthDate: '', gender: '' });
      setError('');
    } catch (error) {
      console.error('Failed to create kid:', error);
      setError('Failed to add kid. Please try again.');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Name:</label>
        <input type="text" name="name" value={kid.name} onChange={handleChange} required />
      </div>
      <div>
        <label>Email:</label>
        <input type="email" name="email" value={kid.email ?? ''} onChange={handleChange} />
      </div>
      <div>
        <label>Birth Date:</label>
        <input type="date" name="birthDate" value={kid.birthDate} onChange={handleChange} required />
      </div>
      <div>
        <label>Gender:</label>
        <select name="gender" value={kid.gender ?? ''} onChange={handleChange}>
          <option value="">Select...</option>
          <option value="Male">Male</option>
          <option value="Female">Female</option>
          <option value="Other">Other</option>
        </select>
      </div>
      {error && <div style={{ color: 'red' }}>{error}</div>}
      <button type="submit">Add Kid</button>
    </form>
  );
};

export default KidForm;
