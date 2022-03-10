import { Injectable } from '@angular/core';
import { of as observableOf, Observable } from 'rxjs';
import { ProgressInfo, StatsProgressBarData } from '../data/stats-progress-bar';

@Injectable()
export class StatsProgressBarService extends StatsProgressBarData {
  private progressInfoData: ProgressInfo[] = [
    {
      title: 'Textils',
      value: 572900,
      activeProgress: 80,
      description: 'Better than last week (70%)',
      status: 'success'
    },
    {
      title: 'Tables',
      value: 6378,
      activeProgress: 60,
      description: 'Better than last week (30%)',
      status: 'primary'
    },
    {
      title: 'Lighting',
      value: 200,
      activeProgress: 30,
      description: 'Better than last week (55%)',
      status: 'warning'
    },
  ];

  getProgressInfoData(): Observable<ProgressInfo[]> {
    return observableOf(this.progressInfoData);
  }
}
