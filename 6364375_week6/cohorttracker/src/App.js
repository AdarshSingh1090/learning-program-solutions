import React from 'react';
import CohortDetails from './CohortDetails';

const cohorts = [
  {
    id: 1,
    name: 'React Bootcamp - Jan',
    status: 'ongoing',
    startDate: '22-Feb-2022',
    endDate: '10-Jun-2022',
  },
  {
    id: 2,
    name: 'React Bootcamp - Sep',
    status: 'completed',
    startDate: '10-Sep-2021',
    endDate: '20-Jan-2022',
  },
  {
    id: 3,
    name: 'React Bootcamp - Dec',
    status: 'completed',
    startDate: '24-Dec-2021',
    endDate: '30-Apr-2022',
  },
  // Add more cohort objects if needed
];

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <h1>Cohorts Details</h1>
      <div
        style={{
          display: 'flex',
          flexWrap: 'wrap',
          gap: '10px',
        }}
      >
        {cohorts.map((cohort) => (
          <CohortDetails key={cohort.id} cohort={cohort} />
        ))}
      </div>
    </div>
  );
}

export default App;
