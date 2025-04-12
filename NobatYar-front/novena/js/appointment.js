// Sample reserved times for demonstration
const reservedTimes = {
    '2023-10-15': ['08:00', '08:30'], // Example of reserved times on this date
    '2023-10-16': ['09:00'], // Reserved time on another date
    // Add more reserved times as needed
};

// Get today's date and the next 10 days
const getNext10Days = () => {
    const days = [];
    const today = new Date();
    for (let i = 0; i < 10; i++) {
        const nextDay = new Date(today);
        nextDay.setDate(today.getDate() + i);
        days.push(nextDay.toISOString().split('T')[0]); // Format to YYYY-MM-DD
    }
    return days;
};

// Variables to hold selected date and time
let selectedDate = null;
let selectedTime = null;

// Generate day cards
const generateDayCards = () => {
    const days = getNext10Days();
    const dayCardsContainer = document.getElementById('dayCards');

    days.forEach(day => {
        const card = document.createElement('div');
        card.classList.add('card', 'col-2', 'm-2', 'text-center', 'p-3');
        card.innerText = new Date(day).toLocaleDateString('en-US', { weekday: 'short', month: 'short', day: 'numeric' });
        card.setAttribute('data-date', day);

        // Disable card if all time slots are reserved
        if (reservedTimes[day] && Object.keys(reservedTimes[day]).length === 8) { // 8 slots means fully booked
            card.classList.add('disabled');
        }

        card.onclick = () => {
            // Deselect previous card
            const previousSelectedDateCard = document.querySelector('.card.selected');
            if (previousSelectedDateCard) {
                previousSelectedDateCard.classList.remove('selected');
            }

            // Select the new card
            card.classList.add('selected');
            selectedDate = day;
            showTimeSlots(day);
        };

        dayCardsContainer.appendChild(card);
    });
};

// Show available time slots
const showTimeSlots = (date) => {
    const timeCardsContainer = document.getElementById('timeCards');
    timeCardsContainer.innerHTML = ''; // Clear previous time slots

    const startHour = 8; // 8 AM
    const endHour = 16; // 4 PM
    const interval = 60; // 60 minutes

    // Generate time cards
    for (let hour = startHour; hour < endHour; hour++) {
        const formattedHour = hour < 12 ? hour : hour - 12;
        const amPm = hour < 12 ? 'AM' : 'PM';
        const timeSlot = `${formattedHour}:00 ${amPm}`;

        const timeCard = document.createElement('div');
        timeCard.classList.add('time-card', 'btn', 'btn-outline-primary', 'm-2', 'text-center', 'p-3');
        timeCard.innerText = timeSlot;

        // Check if the time is reserved
        const formattedTime = `${hour.toString().padStart(2, '0')}:00`;
        if (reservedTimes[date] && reservedTimes[date].includes(formattedTime)) {
            timeCard.classList.add('disabled');
        }

        timeCard.onclick = () => {
            // Deselect previous time card
            const previousSelectedTimeCard = document.querySelector('.time-card.selected');
            if (previousSelectedTimeCard) {
                previousSelectedTimeCard.classList.remove('selected');
            }

            // Select the new time card
            timeCard.classList.add('selected');
            selectedTime = timeSlot; // Store the selected time
        };

        timeCardsContainer.appendChild(timeCard);
    }
};

// Initialize the cards on page load
generateDayCards();